    static object s_lock = new object();
    static IDictionary<Type, Func<BinaryReader, dynamic>> s_readers = null;
    static T ReadData<T>(string fileName)
    {
        lock (s_lock)
        {
            if (s_readers == null)
            {
                s_readers = new Dictionary<Type, Func<BinaryReader, dynamic>>();
                s_readers.Add(typeof(int), r => r.ReadInt32());
                s_readers.Add(typeof(string), r => r.ReadString());
                // Add more here
            }
        }
        if (!s_readers.ContainsKey(typeof(T))) throw new ArgumentException("Invalid type");
        using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
        using (var reader = new BinaryReader(fs))
        {
            return s_readers[typeof(T)](reader);
        }
    }
