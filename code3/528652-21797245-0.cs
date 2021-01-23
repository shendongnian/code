    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        Dim context As HttpContext = HttpContext.Current
        Dim exception As Exception = Server.GetLastError
        'custom exception handling:
        If Not IsNothing(exception) Then
            If Not IsNothing(exception.InnerException) Then
                'detect if viewstate has become currupted:
                If exception.InnerException.GetType = GetType(ViewStateException) Then
                    'Cause:
                    'VIEWSTATE|VIEWSTATEENCRYPTED|EVENTVALIDATION hidden fields are malformed
                    ' + could be page is submitted before being fully loaded
                    ' + hidden fields have been malformed by proxies or user tampering
                    ' + hidden fields have been trunkated by mobile devices
                    ' + remotly loaded content into the page using ajax causes the hidden fields to be overridden with incorrect values (when a user navigates back to a cached page)
                    'Your remedy:
                    'eg: log error message then reload the request page to replenish the viewstate
                    Server.ClearError()
                    Response.Clear()
                    Response.Redirect(context.Request.Url.ToString, False)
                    Exit Sub
                End If
            End If
        End If
    End Sub
