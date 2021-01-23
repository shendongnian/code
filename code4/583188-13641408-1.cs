     _ADPath = ConfigurationManager.AppSettings["ADPath"];
     _Domain = ConfigurationManager.AppSettings["ISDDomain"];
     _UserId = ((BasePage)Page).CurrentUser;
     string[] strUser = _UserId.Split('\\');
     if (strUser.Length == 2)
     {
         _UserId = strUser[1];
     }
    
     // uxLBLoginError.Text = "";
     try
     {
         LdapAuthentication la = new LdapAuthentication(_ADPath);
    
         if (!AdPassRequired)
         {
             //use this if password not required
             _authenticated = la.IsUserGroupMember(_UserId, AdGroupToPass);
         }
         //else
         //{
         //    // use this if password is required
         //    _authenticated = la.IsAuthenticated(_Domain, _UserId, strPassword);
         //}
         if (_authenticated)
         {
             //test the roles functionality
             ((BasePage)Page).GetDBRoleNames(_UserId);
             Session["User_Initial_Validated"] = true;
             Session["isDefault_Loaded"] = true;
             Session["AccessRights"] = AccessRights.Default;
             Session["UserId"] = _UserId;
             //Response.Redirect("~/Default.aspx");
         }
