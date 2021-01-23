    public async void RoamData()
    {
        var roamingFolder = Windows.Storage.ApplicationData.Current.RoamingFolder;
        var needToCreate = false;
    
        try
        {
            var sampleFile = await roamingFolder.GetFileAsync("dataFile.txt");
            string fooBar = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
        }
        catch (Exception)
        {
            // fooBar not found
            needToCreate = true; // set a boolean to create the file. Cant be done here cause you cant await in a catch clause.
        }
    
        if (needToCreate)
        {
            var sampleFile = await roamingFolder.CreateFileAsync("dataFile.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);
            await Windows.Storage.FileIO.WriteTextAsync(sampleFile, "fooBar content of the file.");
        }
    }
