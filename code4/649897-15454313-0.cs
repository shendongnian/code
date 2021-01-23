    Function Index()As ActionResult
      If Request.IsAuthenticated Then
        ' Logged in is TRUE
        Return View(LoggedInUserContentModel)
      Else
        ' Logged in is FALSE
        Return View(SiteGuestUserContentModel)
      End If
    End Function
