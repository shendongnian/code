    If Membership.ValidateUser(login2.UserName, login2.Password) Then
                If Not Request.QueryString("ReturnUrl") Then
                    FormsAuthentication.RedirectFromLoginPage(login2.UserName, False)
                Else
                    FormsAuthentication.SetAuthCookie(login2.UserName, False)
                End If
            Else
                Response.Write("Invalid UserID and Password")
            End If
