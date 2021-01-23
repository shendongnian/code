       try
            {
                SPUser AdminUser = SPContext.Current.Web.AllUsers[@"SHAREPOINT\SYSTEM"];
                var superToken = AdminUser.UserToken;
                HttpContext con = HttpContext.Current;
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite site = new SPSite(SPContext.Current.Site.Url, superToken))
                    {
                        SPServiceContext context = SPServiceContext.GetContext(site);
                        HttpContext.Current = null;
                        UserProfileManager upm = new UserProfileManager(context, false);
                        \\get useprofile code
                     }  
                 });
               HttpContext.Current = con;
            }
            catch (Exception ex)
            {
                throw ex;
            }  
