    public string AzureBackgroundImage
    {
        get {
            if (BackgroundImage.Contains("/"))
                return BackgroundImage.Substring(BackgroundImage.LastIndexOf('/'));
    
            return BackgroundImage;             
        }
    }
