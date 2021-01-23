    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Net;
    using System.Web;
    
    using DotNetOpenAuth.Messaging;
    using DotNetOpenAuth.AspNet;
    using DotNetOpenAuth.AspNet.Clients;
    using Validation;
    
    using Newtonsoft.Json;
    
    namespace OAuthProviders
    {
        /// <summary>
        /// The facebook client.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Facebook", Justification = "Brand name")]
        public sealed class FacebookScopedClient : OAuth2Client
        {
            #region Constants and Fields
    
            /// <summary>
            /// The authorization endpoint.
            /// </summary>
            private const string AuthorizationEndpoint = "https://www.facebook.com/dialog/oauth";
    
            /// <summary>
            /// The token endpoint.
            /// </summary>
            private const string TokenEndpoint = "https://graph.facebook.com/oauth/access_token";
    
            /// <summary>
            /// The _app id.
            /// </summary>
            private readonly string appId;
    
            /// <summary>
            /// The _app secret.
            /// </summary>
            private readonly string appSecret;
    
            private readonly string scope;
    
            #endregion
    
            #region Constructors and Destructors
    
            /// <summary>
            /// Initializes a new instance of the <see cref="FacebookScopedClient"/> class.
            /// </summary>
            /// <param name="appId">
            /// The app id.
            /// </param>
            /// <param name="appSecret">
            /// The app secret.
            /// </param>
            /// <param name="scope">
            /// The scope (requested Facebook permissions).
            /// </param>
            public FacebookScopedClient(string appId, string appSecret, string scope)
                : base("facebook")
            {
                Requires.NotNullOrEmpty(appId, "appId");
                Requires.NotNullOrEmpty(appSecret, "appSecret");
                Requires.NotNullOrEmpty(scope, "scope");
    
                this.appId = appId;
                this.appSecret = appSecret;
                this.scope = scope;
            }
    
            #endregion
    
            #region Methods
    
            /// <summary>
            /// The get service login url.
            /// </summary>
            /// <param name="returnUrl">
            /// The return url.
            /// </param>
            /// <returns>An absolute URI.</returns>
            protected override Uri GetServiceLoginUrl(Uri returnUrl)
            {
                // Note: Facebook doesn't like us to url-encode the redirect_uri value
                var builder = new UriBuilder(AuthorizationEndpoint);
                builder.AppendQueryArgument("client_id", this.appId);
                builder.AppendQueryArgument("redirect_uri", returnUrl.AbsoluteUri);
                builder.AppendQueryArgument("scope", this.scope);
    
                return builder.Uri;
            }
    
            /// <summary>
            /// The get user data.
            /// </summary>
            /// <param name="accessToken">
            /// The access token.
            /// </param>
            /// <returns>A dictionary of profile data.</returns>
            protected override IDictionary<string, string> GetUserData(string accessToken)
            {
                FacebookGraphData graphData;
                var request =
                WebRequest.Create("https://graph.facebook.com/me?access_token=" + UriDataStringRFC3986(accessToken));
                using (var response = request.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        graphData = OAuthJsonHelper.Deserialize<FacebookGraphData>(responseStream);
                    }
                }
    
                // this dictionary must contains
                var userData = new Dictionary<string, string>();
                if (!string.IsNullOrEmpty(graphData.Id)) { userData.Add("id", graphData.Id); }
                if (!string.IsNullOrEmpty(graphData.Email)) { userData.Add("username", graphData.Email); }
                if (!string.IsNullOrEmpty(graphData.Name)) { userData.Add("name", graphData.Name); }
    
                if (graphData.Link != null && !string.IsNullOrEmpty(graphData.Link.AbsoluteUri)) { userData.Add("link", graphData.Link == null ? null : graphData.Link.AbsoluteUri); }
    
                if (!string.IsNullOrEmpty(graphData.Gender)) { userData.Add("gender", graphData.Gender); }
                if (!string.IsNullOrEmpty(graphData.Birthday)) { userData.Add("birthday", graphData.Birthday); }
    
                return userData;
            }
    
            /// <summary>
            /// Obtains an access token given an authorization code and callback URL.
            /// </summary>
            /// <param name="returnUrl">
            /// The return url.
            /// </param>
            /// <param name="authorizationCode">
            /// The authorization code.
            /// </param>
            /// <returns>
            /// The access token.
            /// </returns>
            protected override string QueryAccessToken(Uri returnUrl, string authorizationCode)
            {
                // Note: Facebook doesn't like us to url-encode the redirect_uri value
                var builder = new UriBuilder(TokenEndpoint);
                builder.AppendQueryArgument("client_id", this.appId);
                builder.AppendQueryArgument("redirect_uri", NormalizeHexEncoding(returnUrl.AbsoluteUri));
                builder.AppendQueryArgument("client_secret", this.appSecret);
                builder.AppendQueryArgument("code", authorizationCode);
                builder.AppendQueryArgument("scope", this.scope);
    
                using (WebClient client = new WebClient())
                {
                    string data = client.DownloadString(builder.Uri);
                    if (string.IsNullOrEmpty(data))
                    {
                        return null;
                    }
    
                    var parsedQueryString = HttpUtility.ParseQueryString(data);
                    return parsedQueryString["access_token"];
                }
            }
    
            /// <summary>
            /// Converts any % encoded values in the URL to uppercase.
            /// </summary>
            /// <param name="url">The URL string to normalize</param>
            /// <returns>The normalized url</returns>
            /// <example>NormalizeHexEncoding("Login.aspx?ReturnUrl=%2fAccount%2fManage.aspx") returns "Login.aspx?ReturnUrl=%2FAccount%2FManage.aspx"</example>
            /// <remarks>
            /// There is an issue in Facebook whereby it will rejects the redirect_uri value if
            /// the url contains lowercase % encoded values.
            /// </remarks>
            private static string NormalizeHexEncoding(string url)
            {
                var chars = url.ToCharArray();
                for (int i = 0; i < chars.Length - 2; i++)
                {
                    if (chars[i] == '%')
                    {
                        chars[i + 1] = char.ToUpperInvariant(chars[i + 1]);
                        chars[i + 2] = char.ToUpperInvariant(chars[i + 2]);
                        i += 2;
                    }
                }
                return new string(chars);
            }
    		
    		/// <summary>
            /// The set of characters that are unreserved in RFC 2396 but are NOT unreserved in RFC 3986.
            /// </summary>
            private static readonly string[] UriRfc3986CharsToEscape = new[] { "!", "*", "'", "(", ")" };
    
            internal static string UriDataStringRFC3986(string value)
            {
                // Start with RFC 2396 escaping by calling the .NET method to do the work.
                // This MAY sometimes exhibit RFC 3986 behavior (according to the documentation).
                // If it does, the escaping we do that follows it will be a no-op since the
                // characters we search for to replace can't possibly exist in the string.
                var escaped = new StringBuilder(Uri.EscapeDataString(value));
    
                // Upgrade the escaping to RFC 3986, if necessary.
                for (int i = 0; i < UriRfc3986CharsToEscape.Length; i++)
                {
                    escaped.Replace(UriRfc3986CharsToEscape[i], Uri.HexEscape(UriRfc3986CharsToEscape[i][0]));
                }
    
                // Return the fully-RFC3986-escaped string.
                return escaped.ToString();
            }
    
            #endregion
        }
    }
