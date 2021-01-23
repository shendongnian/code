    public void LoadPage()
    {
        string DestinationUrl = ".../file.asp";
        WebClient wc = new WebClient();
    
        string data = "Some data";
                
        String s = wc.UploadString(DestinationUrl, data);
    }
