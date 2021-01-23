    byte[] buffer = new byte[4];
    List<double> rawData = new List<double>();
    foreach(var path in paths)
    {
        using(var file = File.OpenRead(path))
        {
            while(TryRead(file, buffer, 4))
            {
                const uint MASK = 4095;
                var val = BitConverter.ToUInt32(buffer, 0) & MASK;
                // note that this line looks really dodgy
                rawData.Add((double)val);
            }
        }
    }
