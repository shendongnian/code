    IRandomAccessStream sessionRandomAccess = null;
    try
    {
        StorageFile sessionFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
        sessionRandomAccess = await sessionFile.OpenAsync(FileAccessMode.ReadWrite);
        IOutputStream sessionOutputStream = sessionRandomAccess.GetOutputStreamAt(0);
    
        var sessionSerializer = new DataContractSerializer(typeof(List<MusicFileDict>), new Type[] { typeof(T) });
        sessionSerializer.WriteObject(sessionOutputStream.AsStreamForWrite(), _data);
        await sessionOutputStream.FlushAsync();
    }
    catch (Exception)
    {
    }
    finally
    {
        sessionRandomAccess.Dispose();
    }
