     Imports System
     Imports System.Drawing
     Imports System.Windows.Forms
    Public Class listview
    Inherits Form
    Friend WithEvents btnCreate As Button
    Public Sub New()
        Me.InitializeComponent()
    End Sub
    Private Sub InitializeComponent()
        btnCreate = New Button
        btnCreate.Text = "Create"
        btnCreate.Location = New Point(10, 10)
        Me.Controls.Add(btnCreate)
        Text = "Countries Statistics"
        Size = New Size(450, 245)
        StartPosition = FormStartPosition.CenterScreen
    End Sub
    Private Sub btnCreate_Click(ByVal sender As System.Object, _
                            ByVal e As System.EventArgs) Handles btnCreate.Click
        Dim lvwCountries As ListView = New ListView
        lvwCountries.Location = New Point(10, 40)
        lvwCountries.Width = 420
        lvwCountries.Height = 160
        Controls.Add(lvwCountries)
    End Sub
    Public Shared Sub Main()
        Application.Run(New Exercise)
    End Sub
    End Class
