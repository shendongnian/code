    Public Class test1
        Inherits System.Web.UI.Page
    
        Private Sub go_Click(sender As Object, e As System.EventArgs) Handles go.Click
            Session("user") = user.Text
            Response.Redirect("test2.aspx")
        End Sub
    End Class
