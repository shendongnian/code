    Imports Microsoft.VisualBasic
    
    Public Class SecurityCrm
        Implements IHttpModule
    Public Sub Dispose() Implements System.Web.IHttpModule.Dispose
    End Sub
    Public Sub Init(ByVal context As System.Web.HttpApplication) Implements System.Web.IHttpModule.Init
        AddHandler context.BeginRequest, AddressOf FirstTest
    End Sub
    Private Sub FirstTest(ByVal sender As Object, ByVal e As EventArgs)
        Dim app As HttpApplication
        app = CType(sender, HttpApplication)
            Dim cookie As HttpCookie ' Replace with Session Object
            cookie = app.Request.Cookies("username") ' Replace with your Session
            If cookie Is Nothing Then
                app.Response.redirect("/Cms/LoginSystem/login.asp?u=" & app.Request.Url.AbsolutePath)
                app.Response.end()
            Else
                'app.Response.write("Cookie: " & cookie.value)
            End If
    End Sub
