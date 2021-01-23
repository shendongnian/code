     using Google.Apis.Analytics.v3;
     using Google.Apis.Analytics.v3.Data;
     using Google.Apis.Auth.OAuth2;
     using Google.Apis.Auth.OAuth2.Flows;
     using Google.Apis.Auth.OAuth2.Responses;
     using Google.Apis.Services;
     using Microsoft.AspNet.Identity;
     using Microsoft.Owin.Security;
     using System;
     using System.Threading.Tasks;
     using System.Web;
     using System.Web.Mvc;
    public class HomeController : Controller
    {
        AnalyticsService service;
        public IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        public async Task<ActionResult> AccountList()
        {
            service = new AnalyticsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = await GetCredentialForApiAsync(),
                ApplicationName = "Analytics API sample",
            });
            //Account List
            ManagementResource.AccountsResource.ListRequest AccountListRequest = service.Management.Accounts.List();
            //service.QuotaUser = "MyApplicationProductKey";
            Accounts AccountList = AccountListRequest.Execute();
            return View();
        }
        private async Task<UserCredential> GetCredentialForApiAsync()
        {
            var initializer = new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = ClientId,
                    ClientSecret = ClientSecret,
                },
                Scopes = new[] { "https://www.googleapis.com/auth/analytics.readonly" }
            };
            var flow = new GoogleAuthorizationCodeFlow(initializer);
            var identity = await AuthenticationManager.GetExternalIdentityAsync(DefaultAuthenticationTypes.ApplicationCookie);
            if (identity == null)
            {
                Redirect("/Account/Login");
            }
            var userId = identity.FindFirstValue("GoogleUserId");
            var token = new TokenResponse()
            {
                AccessToken = identity.FindFirstValue("Google_AccessToken"),
                RefreshToken = identity.FindFirstValue("GoogleRefreshToken"),
                Issued = DateTime.FromBinary(long.Parse(identity.FindFirstValue("GoogleTokenIssuedAt"))),
                ExpiresInSeconds = long.Parse(identity.FindFirstValue("GoogleTokenExpiresIn")),
            };
            return new UserCredential(flow, userId, token);
        }
    }
