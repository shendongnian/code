    private static void WriteToDisk<T>(string fileName, T[] vector)
    {
        var correctMethod = typeof(BinaryWriter).GetMethod("Write", new[] { typeof(T), });
        if (correctMethod == null)
            throw new ArgumentException("No suitable overload found for type " + typeof(T), "T");
        using (var stream = new FileStream(fileName, FileMode.Create))
        {
            using (var writer = new BinaryWriter(stream))
            {
               foreach(var v in vector)
                   correctMethod.Invoke(writer, new object[] { v, });
            }
        }
    }
