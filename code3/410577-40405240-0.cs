    For Each thisCookie As System.Web.HttpCookie In response.Cookies
        thisCookie.HttpOnly = True
    
        Dim ipString As String = System.Web.HttpContext.Current.Request.UserHostAddress
    
        If Not IPv4Info.IsPrivateIp(ipString) Then
            thisCookie.Secure = True
        End If
    
    Next thisCookie
