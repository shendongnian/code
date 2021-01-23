        Dim cookie As HttpCookie = New HttpCookie("username")
        cookie.Value = TextBox1.Text
        cookie.Expires = DateAndTime.Now.AddHours(12)
        Response.Cookies.Add(cookie)
        Dim entry As New DirectoryEntry("LDAP://xyz.com/dc=xyz,dc=com", TextBox1.Text, TextBox2.Text)
        Try
            Dim obj As New Object
            obj = entry.NativeObject
            Dim search As New DirectorySearcher(entry)
            search.Filter = "(SAMAccountName=" + TextBox1.Text + ")"
            search.PropertiesToLoad.Add("cn")
            Dim result As SearchResult
            result = search.FindOne()
            If result.Equals(Nothing) then
                MsgBox("Try Again with valid username")
            Else
                MsgBox("User Found!")
            Response.Redirect("~/Dashboard.aspx")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    
    End Sub
