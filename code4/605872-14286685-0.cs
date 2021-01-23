    using (var writer = new BinaryWriter(networkStream))
    {
        foreach (var array in list)
        {
            writer.Write(array.Length);
            for (int i = -; i < array.Length; i++)
            {
                writer.Write(array[i]);
            }
        }
        writer.Write(0);
        writer.Flush();
    }
