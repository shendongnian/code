    public UInt16 checksum
    {
      get
      {
        uint accumulator = 0 ;
        using ( BinaryReader reader = new BinaryReader( new MemoryStream() ) )
        {
          BinaryFormatter bf = new BinaryFormatter();
          bf.Serialize( reader.BaseStream , this ) ;
          reader.BaseStream.Seek(0,SeekOrigin.Begin) ;
          while ( reader.BaseStream.Position < reader.BaseStream.Length )
          {
            ushort value = reader.ReadUInt16() ;
            accumulator += value ;
          }
        }
        return (ushort) accumulator ;
      }
    }
