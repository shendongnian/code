    WebClient wcl;
    
    void Test()
    {
        Uri sUri = new Uri("http://google.com/unknown/folder");
        wcl = new WebClient();
        wcl.OpenReadCompleted += onOpenReadCompleted;
        wcl.OpenReadAsync(sUri);
    }
    
    void onOpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
    {
        if (e.Error != null)
        {
            HttpStatusCode httpStatusCode = GetHttpStatusCode(e.Error);
            if (httpStatusCode == HttpStatusCode.NotFound)
            {
                // 404 found
            }
        }
        else if (!e.Cancelled)
        {
            // Downloaded OK
        }
    }
    
    HttpStatusCode GetHttpStatusCode(System.Exception err)
    {
        if (err is WebException)
        {
            WebException we = (WebException)err;
            if (we.Response is HttpWebResponse)
            {
                HttpWebResponse response = (HttpWebResponse)we.Response;
                return response.StatusCode;
            }
        }
        return 0;
    }
