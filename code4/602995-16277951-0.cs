    private string ConvertToBase64String<T>(T obj) where T : class, IBinarySerializable
    {
         if (obj == null)
             return string.Empty;
         using (var stream = new System.IO.MemoryStream())
         using (var writer = new System.IO.BinaryWriter(stream))
         {
             obj.Write(writer);
             var bytes = stream.ToArray();
             return System.Convert.ToBase64String(bytes);
        }
    }
