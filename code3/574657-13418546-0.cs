    var accessToken = moduleModel.User.AccessToken.Token;
    var urlBuilder = new System.Text.StringBuilder();
    urlBuilder.Append("https://");
    urlBuilder.Append("www.googleapis.com");
    urlBuilder.Append("/calendar/v3/users/me/calendarList");
    urlBuilder.Append("?minAccessRole=writer");
    var httpWebRequest = HttpWebRequest.Create(urlBuilder.ToString()) 
        as HttpWebRequest;
    httpWebRequest.CookieContainer = new CookieContainer();
    httpWebRequest.Headers["Authorization"] = 
        string.Format("Bearer {0}", accessToken);
    var response = httpWebRequest.GetSafeResponse();
    var responseText = response.GetResponseText();
    return responseText;
