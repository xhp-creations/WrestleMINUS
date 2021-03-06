﻿Imports System.IO   'Files
Public Class OptionsMenu
    Private Sub OptionsMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = Me.Text & " Ver: " & My.Application.Info.Version.ToString
        LoadSettings()
    End Sub
    Sub LoadSettings()
        TextBoxHome.Text = Path.GetDirectoryName(My.Settings.ExeLocation)
        TextBoxTexConv.Text = My.Settings.TexConvPath
        If Not File.Exists(My.Settings.TexConvPath) Then
            LabelTexConv.ForeColor = Color.Red
        End If
        TextBoxRadVideo.Text = My.Settings.RADVideoToolPath
        If Not File.Exists(My.Settings.RADVideoToolPath) Then
            LabelRadVideo.ForeColor = Color.Red
        End If
        TextBoxUnrrbpe.Text = My.Settings.UnrrbpePath
        If Not File.Exists(My.Settings.UnrrbpePath) Then
            LabelUnrrbpe.ForeColor = Color.Red
        End If
        If Not MainForm.CheckIconicZlib() Then
            LabelZlib.Text = "Zlib DLL Loaded: False"
            LabelZlib.ForeColor = Color.Red
            ButtonSelectZlib.Visible = True
        End If
        If Not MainForm.CheckOodle() Then
            LabelOodle.Text = "Oodle DLL Loaded: False"
            LabelOodle.ForeColor = Color.Red
            ButtonOodleSelect.Visible = True
        End If
        CheckBoxLoadHome.Checked = My.Settings.LoadHomeOnLaunch
        CheckBoxBackup.Checked = My.Settings.BackupInjections
        CheckBoxDeleteTempBMP.Checked = My.Settings.DeleteTempBMP
        TrackBarHexLength.Value = My.Settings.HexViewLength
        updateviewlength()
    End Sub
    Private Sub ButtonSelectHome_Click(sender As Object, e As EventArgs) Handles ButtonSelectHome.Click
        MainForm.SelectHomeDirectory()
        LoadSettings()
    End Sub
    Private Sub ButtonSelectTexConv_Click(sender As Object, e As EventArgs) Handles ButtonSelectTexConv.Click
        MainForm.GetTexConvExe(True)
        LoadSettings()
    End Sub
    Private Sub ButtonSelectRadVideo_Click(sender As Object, e As EventArgs) Handles ButtonSelectRadVideo.Click
        MainForm.GetRadVideo(True)
        LoadSettings()
    End Sub
    Private Sub ButtonDownloadRadVideo_Click(sender As Object, e As EventArgs) Handles ButtonDownloadRadVideo.Click
        Process.Start("http://www.radgametools.com/bnkdown.htm")
    End Sub

    Private Sub ButtonSelectUnrrbpe_Click(sender As Object, e As EventArgs) Handles ButtonSelectUnrrbpe.Click
        MainForm.GetUnrrbpe()
        LoadSettings()
    End Sub
    Private Sub ButtonDownloadUnrrbpe_Click(sender As Object, e As EventArgs) Handles ButtonDownloadUnrrbpe.Click
        Process.Start("http://asmodean.reverse.net/pages/unrrbpe.html")
    End Sub
    Private Sub ButtonSelectZlib_Click(sender As Object, e As EventArgs) Handles ButtonSelectZlib.Click
        'TO DO
    End Sub
    Private Sub ButtonOodleSelect_Click(sender As Object, e As EventArgs) Handles ButtonOodleSelect.Click
        'TO DO
    End Sub
    Private Sub CheckBoxLoadHome_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxLoadHome.CheckedChanged
        My.Settings.LoadHomeOnLaunch = CheckBoxLoadHome.Checked
    End Sub

    Private Sub CheckBoxBackup_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxBackup.CheckedChanged
        My.Settings.BackupInjections = CheckBoxBackup.Checked
    End Sub

    Private Sub CheckBoxDeleteTempBMP_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxDeleteTempBMP.CheckedChanged
        My.Settings.DeleteTempBMP = CheckBoxDeleteTempBMP.Checked
    End Sub

    Private Sub TrackBarHexLength_Scroll(sender As Object, e As EventArgs) Handles TrackBarHexLength.Scroll
        My.Settings.HexViewLength = TrackBarHexLength.Value
        updateviewlength()
    End Sub
    Sub updateviewlength()
        If TrackBarHexLength.Value > 1024 Then
            LabelHexLength.Text = "Hex/Text View Length: " & CInt(TrackBarHexLength.Value / 1024) & "MB"
        Else
            LabelHexLength.Text = "Hex/Text View Length: " & TrackBarHexLength.Value & "KB"
        End If
    End Sub
    Private Sub ButtonResetStrings_Click(sender As Object, e As EventArgs) Handles ButtonResetStrings.Click
        MainForm.StringReferences = New String(&HFFFFF) {}
        MainForm.StringReferences(0) = "String Not Read"
    End Sub
    Private Sub ButtonResetPacs_Click(sender As Object, e As EventArgs) Handles ButtonResetPacs.Click
        MainForm.PacNumbers = New Integer(1024) {}
        MainForm.PacNumbers(0) = -1
    End Sub
End Class