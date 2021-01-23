    private static void WriteToDisk<T>(string fileName, T[] vector, Action<BinaryWriter, T> callWrite)
    {
        using (var stream = new FileStream(fileName, FileMode.Create))
        {
            using (var writer = new BinaryWriter(stream))
            {
                foreach (T v in vector)
                    callWrite(writer, v);
                writer.Close();
            }
        }
    }
