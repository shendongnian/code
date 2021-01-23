    protected override string QueryAccessToken(Uri returnUrl, string authorizationCode)
            {
                // Note: Facebook doesn't like us to url-encode the redirect_uri value
                var builder = new UriBuilder("https://graph.facebook.com/oauth/access_token");
                builder.AppendQueryArgument("client_id", this.appId);
                builder.AppendQueryArgument("redirect_uri", NormalizeHexEncoding(returnUrl.GetLeftPart(UriPartial.Path)));
                builder.AppendQueryArgument("client_secret", this.appSecret);
                builder.AppendQueryArgument("code", authorizationCode);
    
                using (WebClient client = new WebClient())
                {
                    //Get Accsess  Token
                    string data = client.DownloadString(builder.Uri);
                    if (string.IsNullOrEmpty(data))
                    {
                        return null;
                    }
    
                    var parsedQueryString = HttpUtility.ParseQueryString(data);
                    return parsedQueryString["access_token"];
                }
            }
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
