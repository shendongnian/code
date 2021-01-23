    JavaScriptSerializer jss = new JavaScriptSerializer();
    String json = webbrowser.DocumentText
    TokenResponse token = jss.Deserialize<TokenResponse>(json);
    
       public class TokenResponse
        {
            public string access_token { get; set; }
            public string token_type { get; set; }
            public string expires_in { get; set; }
            public string refresh_token { get; set; }
        }
