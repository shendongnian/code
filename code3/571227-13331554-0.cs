    Public Class UserControl1
      Public Event ButtonClicked(tag As Object)
      Private Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click, Button2.Click, Button3.Click
        RaiseEvent ButtonClicked(CType(sender, Button).Tag)
      End Sub
    End Class
    Public Class Form1
      Private Sub UserControl11_ButtonClicked(tag As Object) Handles UserControl11.ButtonClicked
        TextBox1.Text = tag
      End Sub
    End Class
