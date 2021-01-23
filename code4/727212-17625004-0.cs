      List<UInt16> xyz = new List<UInt16>();
      Byte[] byteArray = null;
      byteArray = xyz.SelectMany(i => BitConverter.GetBytes(i)).ToArray();
      using (BinaryWriter Writer = new BinaryWriter(File.Create("path")))
      {
         foreach (Byte b in byteArray)
         {
            if (b == 0)
            {
               Writer.Write(Byte.MaxValue);
               Writer.Write((Byte) 1);
            }
            else if (b == Byte.MaxValue)
            {
               Writer.Write(Byte.MaxValue);
               Writer.Write(Byte.MaxValue);
            }
            else
            {
               Writer.Write(b);
            }
         }
      }
