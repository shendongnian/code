    CurrentPlaceNowModel model; 
    using (var settings = IsolatedStorageSettings.ApplicationSettings)
    {
        if (settings.Contains("MODEL"))
        {
            model = settings["MODEL"] as CurrentPlaceNowModel;
        }
        else
        {
            model = new CurrentPlaceNowModel();
            settings.Add("MODEL", model);    
            settings.Save();
        }
    }
