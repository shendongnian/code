    private void GetFile()
    {
        var webClient = new WebClient();
    
        webClient.OpenReadCompleted += OpenReadCompleted;
    
        string url = "http://url/encodedfile.txt";         
    
        webClient.OpenReadAsync(new Uri(url));
    }
    private void OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
    {
        // Decrypt the contents of e.Result
    }
