    public void UploadMyFile(string url, string localFilePath)
    {
        using(WebClient client = new WebClient()) {
            client.UploadFile(url,localFilePath);
        }
    }
