    items = await phoneTable
        .Where(PhoneItem => PhoneItem.Publish == true)
        .OrderBy(PhoneItem => PhoneItem.FullName)
        .ToListAsync();
    using (var store = IsolatedStorageFile.GetUserStoreForApplication())
    {
        string offlineData = Path.Combine("WPTracker", "Offline");
        string offlineDataFile = Path.Combine(offlineData, "phones.xml");
        IsolatedStorageFileStream dataFile = null;
        dataFile = store.OpenFile(offlineDataFile, FileMode.Create);
        DataContractSerializer ser = new DataContractSerializer(typeof(IEnumerable<Phones>));
        ser.WriteObject(dataFile, items);
        dataFile.Close();
    }
