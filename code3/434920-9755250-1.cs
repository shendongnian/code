    byte[] SeparateAndGetLast(byte[] source, byte[] separator)
    {
      for (var i = 0; i < source.Length; ++i)
      {
         if(Equals(source, separator, i))
         {
           var index = i + separator.Length;
           var part = new byte[source.Length - index];
           Array.Copy(source, index, part, 0, part.Length);
           return part;
         }
      }
      throw new Exception("not found");
    }
    byte[][] Separate(byte[] source, byte[] separator)
    {
      var parts = new List<byte[]>();
      var index = 0;
      for (var i = 0; i < source.Length; ++i)
      {
         if(Equals(source, separator, i))
         {
           var part = new byte[i - index];
           Array.Copy(source, index, part, 0, part.Length);
           parts.Add(part);
           index = i + separator.Length;
           i += separator.Length - 1;
         }
      }
      return parts.ToArray();
    }
    bool Equals(byte[] source, byte[] separator, int index)
    {
      for (int i = 0; i < separator.Length; ++i)
        if (index + i >= source.Length || source[index + i] != separator[i])
          return false;
      return true;
    }
