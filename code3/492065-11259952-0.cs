    using (BinaryReader br = new BinaryReader(File.Open("file", FileMode.Open)))
    {
      int a = br.ReadInt32();
      int b = br.ReadInt32();
      int c = br.ReadInt32();
      int d = br.ReadInt32();
      double e = br.ReadDouble();
      double f = br.ReadDouble();
      ...
    }
