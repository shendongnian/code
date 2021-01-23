    Public Class Form1
        Private childForm As Form2
        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            childForm = New Form2()
            childForm.Show()
        End Sub
        Private Sub Form1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
            If childForm IsNot Nothing Then
                childForm.Hide()
            End If
        End Sub
    End Class
