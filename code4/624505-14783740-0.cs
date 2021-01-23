    Public Class Form1
        Private Hero As New Button
        Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Hero.Parent = Me
            Hero.Enabled = False
        End Sub
        Private Sub Form1_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles Me.PreviewKeyDown
            Select Case e.KeyCode
                Case Keys.Left
                    Hero.Left -= 5
                Case Keys.Right
                    Hero.Left += 5
                Case Keys.Down
                    Hero.Top += 5
                Case Keys.Up
                    Hero.Top -= 5
            End Select
        End Sub
    End Class
