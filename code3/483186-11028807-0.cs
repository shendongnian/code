    // Create the data to save.
    SaveGameData data = new SaveGameData();
    data.PlayerName = "Hiro";
    data.AvatarPosition = new Vector2(360, 360);
    data.Level = 11;
    data.Score = 4200;
    
    // Open a storage container.
    IAsyncResult result =
        device.BeginOpenContainer("StorageDemo", null, null);
    
    // Wait for the WaitHandle to become signaled.
    result.AsyncWaitHandle.WaitOne();
    
    StorageContainer container = device.EndOpenContainer(result);
    
    // Close the wait handle.
    result.AsyncWaitHandle.Close();
    
    string filename = "savegame.sav";
    
    // Check to see whether the save exists.
    if (container.FileExists(filename))
        // Delete it so that we can create one fresh.
        container.DeleteFile(filename);
    
    // Create the file.
    Stream stream = container.CreateFile(filename);
    
    // Convert the object to XML data and put it in the stream.
    XmlSerializer serializer = new XmlSerializer(typeof(SaveGameData));
    serializer.Serialize(stream, data);
    
    // Close the file.
    stream.Close();
    
    // Dispose the container, to commit changes.
    container.Dispose();
