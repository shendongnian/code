    StorageFile sessionFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(GUID, CreationCollisionOption.OpenIfExists);
    if (sessionFile == null)
        return Guid.Empty;
    using (IInputStream sessionInputStream = await sessionFile.OpenReadAsync())
    {
        var sessionSerializer = new DataContractSerializer(typeof(Guid));
        Guid val;
        return sessionSerializer.TryReadObject<Guid>(
            sessionInputStream.AsStreamForRead(), out val) ? val : Guid.Empty;
    }
