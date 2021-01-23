    private static AsyncLock mutex = new AsyncLock();
    public static async Task SaveDataToFileAsync<T>(string key, T value, bool roaming = false, Type[] extraTypes = null)
    {
      using (await mutex.LockAsync())
      {
        var file = roaming ? await KnownFolders.DocumentsLibrary.CreateFileAsync(key + ".xml", CreationCollisionOption.ReplaceExisting) :
        await KnownFolders.DocumentsLibrary.CreateFileAsync(key + ".xml", CreationCollisionOption.ReplaceExisting);
        var xml = Xml.Serialize<T>(value, extraTypes);
        await FileIO.WriteTextAsync(file, xml, UnicodeEncoding.Utf8);
      }
    }
