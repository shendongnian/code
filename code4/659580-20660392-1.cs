    string note = string.Empty;
    IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
    if (settings.Contains("note"))
    {
        note = settings["note"] as string;
    }
