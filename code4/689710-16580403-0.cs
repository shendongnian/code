    private async Task Save(string fileName)
    {
        Button.IsEnabled = false;
    
        await Task.Run(() =>
            {
                using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication())
                {
    
                    using (IsolatedStorageFileStream stream = isoStore.CreateFile(filename))
                    {
                        XmlSerializer xml = new XmlSerializer(GetType());
                        xml.Serialize(stream, this);
                    }
                }
            });
    
        Button.IsEnabled = true;
    }
