    public class SecurityUtil : ISecurityUtil
    {
        public string DatabaseUserName { get { return LocalUserManager.GetUserName(); } }
        
        public bool PromptSecurityCheck(string securityContext)
        {
            bool ret = IsAuthorized(securityContext);
            if (!ret)
            {
                MessageBox.Show(string.Format("You are not authorised to perform the action '{0}'.", securityContext), Settings.Default.AppTitle,
                                            MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return ret;
        }
        public bool IsAuthorized(string securityContext)
        {
            IAuthorizationProvider ruleProvider = AuthorizationFactory.GetAuthorizationProvider("MyAuthorizationProvider");
            //bool ret = ruleProvider.Authorize(LocalUserManager.GetThreadPrinciple(), securityContext);
            bool ret = ruleProvider.Authorize(LocalUserManager.GetCurrentPrinciple(), securityContext);            
            return ret;
        }
        public string GetFullyQualifiedName(object element)
        {
            return element.GetType().FullName;
        }
        public string GetFullyQualifiedObjectName(object hostControl, string objectName)
        {
            return GetFullyQualifiedName(hostControl) + "." + objectName;
        }
    }
    [ConfigurationElementType(typeof(CustomAuthorizationProviderData))]
    public class MyAuthorizationProvider : AuthorizationProvider
    {
        public SitesAuthorizationProvider(NameValueCollection configurationItems)
        {
        }
        public override bool Authorize(IPrincipal principal, string context)
        {
            bool ret = false;
            if (principal.Identity.IsAuthenticated)
            {
                // check the security item key, otherwise check the screen uri
                ret = LocalCacheManager.GetUserSecurityItemsCache(LocalUserManager.UserId, false).Exists(
                    si => si.SecurityItemKey.Equals(context, StringComparison.InvariantCultureIgnoreCase));
                if (!ret)
                {
                    // check if this item matches a screen uri
                    ret = LocalCacheManager.GetUserSecurityItemsCache(LocalUserManager.UserId, false).Exists(
                    si => si.Uri.Equals(context, StringComparison.InvariantCultureIgnoreCase));
                }
            }
            return ret;
        }
    }
