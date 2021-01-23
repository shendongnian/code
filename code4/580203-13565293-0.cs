        double d = -0.0139519833028316;
        byte[] raw;
        using (var ms = new MemoryStream())
        {
            using (var writer = new BinaryWriter(ms))
            {
                writer.Write(d);
            }
            raw = ms.ToArray();
        }
        double newVal;
        using(var ms = new MemoryStream(raw))
        using (var reader = new BinaryReader(ms))
        {
            newVal = reader.ReadDouble();
        }
        Console.WriteLine(newVal == d); // True
