    public class AuthorizationHandler : DelegatingHandler
    {
        private readonly IAuthenticationService _authenticationService = new AuthenticationService();
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var cookie = request.Headers.GetCookies(Constants.ApiKey).FirstOrDefault();
            if (cookie != null)
            {
                var apiKey = cookie[Constants.ApiKey].Value;
                try
                {
                    var guidKey = Guid.Parse(apiKey);
                    var user = _authenticationService.GetUserByKey(guidKey);
                    if (user != null)
                    {
                        var userIdClaim = new Claim(ClaimTypes.Name, apiKey);
                        var identity = new ClaimsIdentity(new[] { userIdClaim }, "ApiKey");
                        var principal = new ClaimsPrincipal(identity);
                        Thread.CurrentPrincipal = principal;
                    }
                }
                catch (FormatException)
                {
                }
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
