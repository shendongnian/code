    string data;
    // fill the json in data variable
    ItemCollection collection;
    using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(data)))
    {
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ItemCollection));
        collection = (ItemCollection)serializer.ReadObject(ms);
    }
    
