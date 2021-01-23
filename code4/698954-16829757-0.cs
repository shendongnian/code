    static CustomSampleData DeserializeCustom(Byte[] b)
    {
        var csd = new CustomSampleData();
        using(var ms = new MemoryStream(b))
        {
          using (var br = new BinaryReader(ms))
          {
            csd.FName = br.ReadString();
            ...
          }
        }
        return csd;
    }
