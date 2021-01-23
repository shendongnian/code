    Using ctx As New DataContexts.SBWebs
    	Dim u As DataEntities.User = (From usr In ctx.Users Where usr.User.Equals(Page.User.Identity.Name) Select usr).FirstOrDefault
    	If u Is Nothing Then Exit Sub
    
    	Dim id As Guid = Guid.NewGuid
    
    	u.Token = id
    	ctx.SubmitChanges()
    
    	Dim newPath As String = "/protected/?tick=" & Now.Ticks
    	Response.Redirect(String.Format("http://www.domain2.local/EndPoint.aspx?tokenid={0}&ReturnUrl={1}", id.ToString, HttpUtility.UrlEncode(newPath)))
    End Using
And the EndPoint.aspx contains the following code..
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    	If Request.QueryString.HasKeys AndAlso Not String.IsNullOrEmpty(Request.QueryString("tokenid")) Then
    		Using ctx As New DataContexts.SBWebs
    			Dim usr As DataEntities.User = (From u In ctx.Users Where u.Token.Equals(Request.QueryString("tokenid"))).FirstOrDefault
    			If usr Is Nothing Then Exit Sub
    
    			usr.Token = Nothing
    			ctx.SubmitChanges()
    
    			FormsAuthentication.RedirectFromLoginPage(usr.User, False)
    		End Using
    	End If
    End Sub
