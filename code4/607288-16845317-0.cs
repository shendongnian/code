    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web.Security;
    using ServiceStack.Configuration;
    using ServiceStack.Logging;
    using ServiceStack.ServiceInterface;
    using ServiceStack.ServiceInterface.Auth;
    using ServiceStack.WebHost.Endpoints;
    using umbraco.BusinessLogic;
    using umbraco.providers;
    public class UmbracoAuthProvider : CredentialsAuthProvider
    {
        public UmbracoAuthProvider(IResourceManager appSettings)
        {
            this.Provider = "umbraco";
        }
        private UmbracoAuthConfig AuthConfig
        {
            get
            {
                return EndpointHost.AppHost.TryResolve<UmbracoAuthConfig>();
            }
        }
        public override void OnAuthenticated(IServiceBase authService, IAuthSession session, IOAuthTokens tokens, Dictionary<string, string> authInfo)
        {
            ILog log = LogManager.GetLogger(this.GetType());
            var membershipProvider = (UsersMembershipProvider)Membership.Providers["UsersMembershipProvider"];
            if (membershipProvider == null)
            {
                log.Error("UmbracoAuthProvider.OnAuthenticated - NullReferenceException - UsersMembershipProvider");
                session.IsAuthenticated = false;
                return;
            }
            MembershipUser user = membershipProvider.GetUser(session.UserAuthName, false);
            if (user == null)
            {
                log.ErrorFormat(
                    "UmbracoAuthProvider.OnAuthenticated - GetMembershipUser failed - {0}", session.UserAuthName);
                session.IsAuthenticated = false;
                return;
            }
            if (user.ProviderUserKey == null)
            {
                log.ErrorFormat(
                    "UmbracoAuthProvider.OnAuthenticated - ProviderUserKey failed - {0}", session.UserAuthName);
                session.IsAuthenticated = false;
                return;
            }
            User umbracoUser = User.GetUser((int)user.ProviderUserKey);
            if (umbracoUser == null || umbracoUser.Disabled)
            {
                log.WarnFormat(
                    "UmbracoAuthProvider.OnAuthenticated - GetUmbracoUser failed - {0}", session.UserAuthName);
                session.IsAuthenticated = false;
                return;
            }
            session.UserAuthId = umbracoUser.Id.ToString(CultureInfo.InvariantCulture);
            session.Email = umbracoUser.Email;
            session.DisplayName = umbracoUser.Name;
            session.IsAuthenticated = true;
            session.Roles = new List<string>();
            if (umbracoUser.UserType.Name == "Administrators")
            {
                session.Roles.Add(RoleNames.Admin);
            }
            authService.SaveSession(session);
            base.OnAuthenticated(authService, session, tokens, authInfo);
        }
        public override bool TryAuthenticate(IServiceBase authService, string userName, string password)
        {
            ILog log = LogManager.GetLogger(this.GetType());
            var membershipProvider = (UsersMembershipProvider)Membership.Providers["UsersMembershipProvider"];
            if (membershipProvider == null)
            {
                log.Error("UmbracoAuthProvider.TryAuthenticate - NullReferenceException - UsersMembershipProvider");
                return false;
            }
            if (!membershipProvider.ValidateUser(userName, password))
            {
                log.WarnFormat("UmbracoAuthProvider.TryAuthenticate - ValidateUser failed - {0}", userName);
                return false;
            }
            MembershipUser user = membershipProvider.GetUser(userName, false);
            if (user == null)
            {
                log.ErrorFormat("UmbracoAuthProvider.TryAuthenticate - GetMembershipUser failed - {0}", userName);
                return false;
            }
            if (user.ProviderUserKey == null)
            {
                log.ErrorFormat("UmbracoAuthProvider.TryAuthenticate - ProviderUserKey failed - {0}", userName);
                return false;
            }
            User umbracoUser = User.GetUser((int)user.ProviderUserKey);
            if (umbracoUser == null || umbracoUser.Disabled)
            {
                log.WarnFormat("UmbracoAuthProvider.TryAuthenticate - GetUmbracoUser failed - {0}", userName);
                return false;
            }
            if (umbracoUser.UserType.Name == "Administrators"
                || umbracoUser.GetApplications()
                              .Any(app => this.AuthConfig.AllowedApplicationAliases.Any(s => s == app.alias)))
            {
                return true;
            }
            log.WarnFormat("UmbracoAuthProvider.TryAuthenticate - AllowedApplicationAliases failed - {0}", userName);
            return false;
        }
    }
    public class UmbracoAuthConfig
    {
        public UmbracoAuthConfig(IResourceManager appSettings)
        {
            this.AllowedApplicationAliases = appSettings.GetList("UmbracoAuthConfig.AllowedApplicationAliases").ToList();
        }
        public List<string> AllowedApplicationAliases { get; private set; }
    }
