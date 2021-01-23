    using System.Runtime.Caching;    // At top of file
    public IEnumerable<MyDataObject> GetData() 
    {
        IEnumerable<MyDataObject> data = MemoryCache.Default.Get(MYCACHEKEY) as IEnumerable<MyDataObject>;
        if (data == null)
        {
            data = // actually get your data from the database here
            MemoryCache.Default.Add(MYCACHEKEY, data, DateTimeOffset.Now.AddHours(24));
        }
        return data;
    }
