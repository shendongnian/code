    StorageFile sessionFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(GUID, CreationCollisionOption.OpenIfExists);
    if (sessionFile == null)
        return Guid.Empty;
    using (IInputStream sessionInputStream = await sessionFile.OpenReadAsync())
    {
        Guid val;
        return sessionInputStream.TryReadObject<Guid>(out val) ? val : Guid.Empty;
    }
