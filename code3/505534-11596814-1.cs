    // ^ previous code ^
    HttpWebResponse getResponse = (HttpWebResponse)getRequest.GetResponse();
    StreamReader sr = new StreamReader(getResponse.GetResponseStream());
    string source = sr.ReadToEnd();
    Uri facebookPage = new Uri("http://www.facebook.com"); // .GetCookies() only accepts a Uri
    cookies.Add(request.CookieContainer.GetCookies(facebookPage));
    getResponse.Close(); // Always make sure you close your responses
    // V requesting your profile code V
