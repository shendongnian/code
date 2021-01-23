    using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
    {
     	XDocument xml = null;
        //Read the file stream into an XDocument using a reading stream
        using (IsolatedStorageFileStream isoFileStream = myIsolatedStorage.OpenFile("Configuration.xml", FileMode.Open, FileAccess.Read))
        {
            xml = XDocument.Load(isoFileStream, LoadOptions.None);
            xml.Element("ConfigData").SetElementValue("CallerNo1", "11111");
        }
        
        //Write it back out using a write one.
        using (IsolatedStorageFileStream isoFileStream = myIsolatedStorage.OpenFile("Configuration.xml", FileMode.Truncate, FileAccess.Write))
        {
            xml.Save(isoFileStream, SaveOptions.None);
        }
     }
