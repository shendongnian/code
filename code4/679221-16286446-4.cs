    public UserModel()
    {
        WebClient request = new WebClient();
        string response = request.DownloadString(url);
        jsonModel = JsonConvert.DeserializeObject<JsonModel>(response);
    }
