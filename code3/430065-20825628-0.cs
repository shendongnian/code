    try
    {
    var file = await StorageFile.GetFileFromPathAsync(path);
    MusicProperties musicProperties = await file.Properties.GetMusicPropertiesAsync();
    }
    catch(Exception e){
    //Error Message here
    }
