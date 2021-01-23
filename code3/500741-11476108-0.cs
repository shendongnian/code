    Imports System.Security.Principal
    
    Public Class ValModule
        Implements IHttpModule
    
        Public Sub Dispose() Implements System.Web.IHttpModule.Dispose
    
        End Sub
    
        Public Sub Init(ByVal context As System.Web.HttpApplication) Implements System.Web.IHttpModule.Init
            AddHandler context.AuthenticateRequest, AddressOf OnRequest
        End Sub
    
        Public Sub OnRequest(ByVal sender As Object, ByVal e As EventArgs)
            ' Fires upon attempting to authenticate the use
            Dim req As HttpRequest = HttpContext.Current.Request
    
            If Not String.IsNullOrEmpty(req.QueryString("tokenid")) Then
                Using ctx As New DataContexts.SBWebs
                    Dim c As DataEntities.Token = (From t In ctx.Tokens Where t.Id.Equals(New Guid(req.QueryString("tokenid"))) Select t).FirstOrDefault
                    If c Is Nothing Then Exit Sub
    
                    Dim ticket As System.Web.Security.FormsAuthenticationTicket = FormsAuthentication.Decrypt(c.Token)
                    If ticket Is Nothing Then Exit Sub
    
                    Dim identity As FormsIdentity = New FormsIdentity(ticket)
    
                    HttpContext.Current.User = New GenericPrincipal(identity, Nothing)
    
                    'Remove the token from database to foil replay attacks.
                    ctx.Tokens.DeleteOnSubmit(c)
                    ctx.SubmitChanges()
                End Using
            End If
        End Sub
    End Class
