    Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
    
    // Create a setting in a container
    
    Windows.Storage.ApplicationDataContainer container = 
       localSettings.CreateContainer("FilesToPersist", Windows.Storage.ApplicationDataCreateDisposition.Always);
    
    StorageFile file = fileYouWantToPersist; 
    
    if (localSettings.Containers.ContainsKey("FilesToPersist"))
    {
    
       localSettings.Containers["FilesToPersist"].Values[file.FolderRelativeId] = DateTime.Now.AddDays(30);
    }
    
    // Read data from a setting in a container
    
    bool hasContainer = localSettings.Containers.ContainsKey("FilesToPersist");
    bool hasSetting = false;
    
    if (hasContainer)
    {
       hasSetting = localSettings.Containers["FilesToPersist"].Values.ContainsKey(file.FolderRelativeId);
        if(hasSettings)
        {
             string dt =    localSettings.Containers["FilesToPersist"].Values[file.FolderRelativeId];
             if(Convert.ToDateTime(dt) < DateTime.Now)
             {
                 //Delete the file
             }
        }
    }
