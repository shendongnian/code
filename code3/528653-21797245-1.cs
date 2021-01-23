    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        Dim context As HttpContext = HttpContext.Current
        Dim exception As Exception = Server.GetLastError
        'custom exception handling:
        If Not IsNothing(exception) Then
            If Not IsNothing(exception.InnerException) Then
                'ViewState Exception:
                If exception.InnerException.GetType = GetType(ViewStateException) Then
                    'The state information is invalid for this page and might be corrupted.
                    'Caused by VIEWSTATE|VIEWSTATEENCRYPTED|EVENTVALIDATION hidden fields being malformed
                    ' + could be page is submitted before being fully loaded
                    ' + hidden fields have been malformed by proxies or user tampering
                    ' + hidden fields have been trunkated by mobile devices
                    ' + remotly loaded content into the page using ajax causes the hidden fields to be overridden with incorrect values (when a user navigates back to a cached page)
                    'Remedy: reload the request page to replenish the viewstate:
                    Server.ClearError()
                    Response.Clear()
                    Response.Redirect(context.Request.Url.ToString, False)
                    Exit Sub
                End If
            End If
        End If
    End Sub
