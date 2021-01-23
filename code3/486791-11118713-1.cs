    public void GetImages()   
    {   
        string uri = "http://sherutnetphpapi.cloudapp.net/mini_logos/" + path;      
        WebClient m_webClient = new WebClient();   
        imageUri = new Uri(uri, UriKind.Relative);   
        m_webClient.OpenReadAsync(imageUri);  
        m_webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(webClient_ImageOpenReadCompleted);   
        m_webClient.AllowReadStreamBuffering = true;  
        
    } 
    void webClient_ImageOpenReadCompleted(object sender, OpenReadCompletedEventArgs e) 
    {        
        var isolatedfile = IsolatedStorageFile.GetUserStoreForApplication(); 
        using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(path, System.IO.FileMode.Create, isolatedfile)) 
        { 
            byte[] buffer = new byte[e.Result.Length]; 
            while (e.Result.Read(buffer, 0, buffer.Length) > 0) 
            { 
                stream.Write(buffer, 0, buffer.Length); 
            } 
        }
    }
