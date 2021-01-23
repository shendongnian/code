    public void SaveStringObject()
    {
        var settings = IsolatedStorageSettings.ApplicationSettings;
        settings.Add("myContent", "foobar");
    }
