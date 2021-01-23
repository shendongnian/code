    public T Read<T>()
    {
        var byteSize = Marshal.SizeOf(typeof(T));
        using (var ms = new MemoryStream())
        {
            ms.Write(SerializedParams, 0, SerializedParams.Length);
            var bf = new BinaryFormatter();
            ms.Position = 0; // this line should do the trick
            var x = bf.Deserialize(ms); 
            return (T)x;
        }
    }
