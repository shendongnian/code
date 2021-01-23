    using System;
    using System.Collections.Generic;
    using System.Text;
    using DotNetOpenAuth.AspNet;
    using System.Web;
    using System.Net;
    using System.IO;
    using System.Text.RegularExpressions;
    using Newtonsoft.Json;
    
    namespace UserAccounts.WebApi.ExternalLogin
    {
        // Thnks to Har Kaur https://www.c-sharpcorner.com/blogs/facebook-integration-by-using-oauth and https://github.com/mj1856/DotNetOpenAuth.GoogleOAuth2/blob/master/DotNetOpenAuth.GoogleOAuth2/GoogleOAuth2Client.cs
        public class FacebookScopedClient : IAuthenticationClient
        {
            private string appId;
            private string appSecret;
            private static string providerName = "Facebook";
    
            private const string baseUrl = "https://www.facebook.com/dialog/oauth?client_id=";
            public const string graphApiToken = "https://graph.facebook.com/oauth/access_token?";
            public const string graphApiMe = "https://graph.facebook.com/me?";
    
    
            private static string GetHTML(string URL)
            {
                string connectionString = URL;
    
                try
                {
                    System.Net.HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(connectionString);
                    myRequest.Credentials = CredentialCache.DefaultCredentials;
                    //// Get the response  
                    WebResponse webResponse = myRequest.GetResponse();
                    Stream respStream = webResponse.GetResponseStream();
                    ////  
                    StreamReader ioStream = new StreamReader(respStream);
                    string pageContent = ioStream.ReadToEnd();
                    //// Close streams  
                    ioStream.Close();
                    respStream.Close();
                    return pageContent;
                }
                catch (WebException ex)
                {
                    StreamReader reader = new StreamReader(ex.Response.GetResponseStream());
                    string line;
                    StringBuilder result = new StringBuilder();
                    while ((line = reader.ReadLine()) != null)
                    {
                        result.Append(line);
                    }
    
                }
                catch (Exception)
                {
                }
                return null;
            }
    
    
            private IDictionary<string, string> GetUserData(string accessCode, string redirectURI)
            {
                string value = "";
                string token = GetHTML(graphApiToken + "client_id=" + appId + "&redirect_uri=" +
                                        HttpUtility.UrlEncode(redirectURI) + "&client_secret=" +
                                           appSecret + "&code=" + accessCode);
                if (token == null || token == "")
                {
                    return null;
                }
                if (token != null || token != "")
                {
                    if (token.IndexOf("access_token") > -1)
                    {
                        string[] arrtoken = token.Replace("\''", "").Split(':');
                        string[] arrval = arrtoken[1].ToString().Split(',');
                        value = arrval[0].ToString().Replace("\"", "");
                    }
                }
                string data = GetHTML(graphApiMe + "fields=id,name,email,gender,link&access_token=" + value);
    
    
                // this dictionary must contains  
                Dictionary<string, string> userData = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
                return userData;
            }
    
    
            public FacebookScopedClient(string appId, string appSecret)
            {
                this.appId = appId;
                this.appSecret = appSecret;
            }
    
            public string ProviderName
            {
                get { return providerName; }
            }
    
            public void RequestAuthentication(System.Web.HttpContextBase context, Uri returnUrl)
            {
                var uriBuilder = new UriBuilder(returnUrl);
                uriBuilder.Query = "";
                var newUri = uriBuilder.Uri;
    
                string returnUrlQuery = HttpUtility.UrlEncode(returnUrl.Query);
                string url = baseUrl + appId + "&scope=email" + "&state=" + returnUrlQuery + "&redirect_uri=" + HttpUtility.UrlEncode(newUri.ToString());
                context.Response.Redirect(url);
            }
    
            public AuthenticationResult VerifyAuthentication(System.Web.HttpContextBase context)
            {
                string code = context.Request.QueryString["code"];
    
                string rawUrl = context.Request.Url.OriginalString;
                //From this we need to remove code portion  
                rawUrl = Regex.Replace(rawUrl, "&code=[^&]*", "");
                var uriBuilder = new UriBuilder(rawUrl);
                uriBuilder.Query = "";
                var newUri = uriBuilder.Uri;
    
                IDictionary<string, string> userData = GetUserData(code, newUri.ToString());
    
                if (userData == null)
                    return new AuthenticationResult(false, ProviderName, null, null, null);
    
                string id = userData["id"];
                string username = userData["email"];
                userData.Remove("id");
                userData.Remove("email");
    
                AuthenticationResult result = new AuthenticationResult(true, ProviderName, id, username, userData);
                return result;
            }
    
            /// <summary>
            /// Facebook requires that all return data be packed into a "state" parameter.
            /// This should be called before verifying the request, so that the url is rewritten to support this.
            /// Thnks to Matt Johnson mj1856 https://github.com/mj1856/DotNetOpenAuth.GoogleOAuth2/blob/master/DotNetOpenAuth.GoogleOAuth2/GoogleOAuth2Client.cs
            /// </summary>
            /// 
            public static void RewriteRequest()
            {
                var ctx = HttpContext.Current;
    
                var stateString = HttpUtility.UrlDecode(ctx.Request.QueryString["state"]);
                if (stateString == null || !stateString.Contains("__provider__=" + providerName)) return;
    
                var q = HttpUtility.ParseQueryString(stateString);
                q.Add(ctx.Request.QueryString);
                q.Remove("state");
    
                ctx.RewritePath(ctx.Request.Path + "?" + q);
            }
        }
    }
