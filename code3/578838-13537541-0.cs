    Public Class UserControl1
      Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim frm As New Form2
        Dim p = frm.PointToScreen(New Point(Me.Left, Me.Bottom))
        frm.Location = New Point(Me.ParentForm.Left, Me.ParentForm.Top + 40) + p
        frm.Show()
      End Sub
    End Class
