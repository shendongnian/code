    Public Class _PageBase
        Inherits System.Web.UI.Page
    
    #Region "Page Functions"
    
        Private Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
            Session("error_StackTrace") = Server.GetLastError.StackTrace.ToString
            Session("error_Message") = Server.GetLastError.Message.ToString
            Session("error_Page") = Request.Url.ToString
            Session("error_Source") = Server.GetLastError.Source.ToString
    
            Server.ClearError()
    
            Response.Redirect("~/errors/Error.aspx")
        End Sub
    
    #End Region
    
    End Class
