    byte[] GetBytesBigEndian(float f)
    {
      var bytes = BitConverter.GetBytes(f);
      if(BitConverter.IsLittleEndian)
        return bytes.Reverse().ToArray();
      else
        return bytes;
    }
