    private void getAccessToken()
    {
        if (App.Current.Properties.Contains("auth_code"))
        {
            makeAccessTokenRequest(accessTokenUrl + App.Current.Properties["auth_code"]);
        }
    }
    
    private void makeAccessTokenRequest(string requestUrl)
    {
        try
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(accessToken_DownloadStringCompleted);
            wc.DownloadStringAsync(new Uri(requestUrl));
            lError.Content = "";
        }
        catch (Exception ex)
        {
            lError.Content = "There has been an internet connection error.";
        }
    }
    
    void accessToken_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
        tokenData = deserializeJson(e.Result);
        if (tokenData.ContainsKey("access_token"))
        {
            App.Current.Properties.Add("access_token", tokenData["access_token"]);
            App.Current.Properties.Add("refresh_token", tokenData["refresh_token"]);
            getUserInfo();
        }
    }
     
    private Dictionary<string, string> deserializeJson(string json)
    {
        var jss = new JavaScriptSerializer();
        var d = jss.Deserialize<Dictionary<string, string>>(json);
        return d;
    }
    
    private void getUserInfo()
    {
        if (App.Current.Properties.Contains("access_token"))
        {
            try
            {
                makeApiRequest(apiUrl + "me?access_token=" + App.Current.Properties["access_token"]);
                lError.Content = "";
            }
            catch (Exception ex)
            {
                lError.Content = "There has been an internet connection error.";
            }
        }
    }
    
    private void makeApiRequest(string requestUrl)
    {
        try
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
            wc.DownloadStringAsync(new Uri(requestUrl));
            lError.Content = "";
        }
        catch (Exception ex)
        {
            lError.Content = "There has been an internet connection error.";
        }
    }
    
    void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
        changeView(e.Result);
    }
    
    private void changeView(string result)
    {
        string imgUrl = apiUrl + "me/picture?access_token=" + App.Current.Properties["access_token"];
        imgUser.Source = new BitmapImage(new Uri(imgUrl, UriKind.RelativeOrAbsolute));
        String code = "" + App.Current.Properties["refresh_token"];
        String auth = "" + App.Current.Properties["access_token"];
    
    }
    
    void browser_Closed(object sender, EventArgs e)
    {
        try
        {
            getAccessToken();
            lError.Content = "";
        }
        catch (Exception ex)
        {
            lError.Content = "There has been an internet connection error.";
        }
    } 
