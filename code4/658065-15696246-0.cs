    // Check for data files and copy them to isolated storage if they're not there...
    // See below for methods found in simple IsolatedStorageHelper class
    var isoHelper = new IsolatedStorageHelper();
    if (!isoHelper.FileExists("MyDataFile.xml"))
    {
        isoHelper.SaveFilesToIsoStore(new[] { "Data\\MyDataFile.xml" }, null);
    }
    /* IsolatedStorageHelper Methods */
    /// <summary>
    /// Copies the content files from the application package into Isolated Storage.
    /// This is done only once - when the application runs for the first time.
    /// </summary>
    public void SaveFilesToIsoStore(string[] files)
    {
        SaveFilesToIsoStore(files, null);
    }
    /// <summary>
    /// Copies the content files from the application package into Isolated Storage.
    /// This is done only once - when the application runs for the first time.
    /// </summary>
    public void SaveFilesToIsoStore(string[] files, string basePath)
    {
        var isoStore = IsolatedStorageFile.GetUserStoreForApplication();
        foreach (var path in files)
        {
            var fileName = Path.GetFileName(path);
            if (basePath != null)
            {
                fileName = Path.Combine(basePath, fileName);
            }
            // Delete the file if it's already there
            if (isoStore.FileExists(fileName))
            {
                isoStore.DeleteFile(fileName);
            }
            var resourceStream = Application.GetResourceStream(new Uri(path, UriKind.Relative));
            using (var reader = new BinaryReader(resourceStream.Stream))
            {
                var data = reader.ReadBytes((int)resourceStream.Stream.Length);
                SaveToIsoStore(fileName, data);
            }
        }
    }
