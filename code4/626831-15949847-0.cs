    private SvnClient GetClient()
    {
        SvnClient client = new SvnClient();
        // Note: Settings creds up here is optional
        // client.Authentication.DefaultCredentials = _creds;
        string configPath = Path.Combine(Path.GetTempPath(), "sharpsvn");
        if (!Directory.Exists(configPath))
        {
            Directory.CreateDirectory(configPath);
        }
        client.LoadConfiguration(configPath, true);
        return client;
    }
