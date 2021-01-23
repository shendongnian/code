    using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
    {
        if (store.FileExists(fileName))
        {
            client.BackgroundUploadAsync("me/skydrive", new Uri(fileName, UriKind.Relative),
                                            OverwriteOption.Overwrite);
        }
    }
