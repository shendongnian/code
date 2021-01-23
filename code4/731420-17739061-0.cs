    public void WriteResrouce(string resourcePath, string targetPath)
    {
        var buffer = new byte[64 * 1024]; //i've picked 64k as a reasonable sized block
        using (Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath))
        using (var sw = new BinaryWriter(File.Open(targetPath, FileMode.OpenOrCreate)))
        {
            var readCount = -1;
            while (0 < (readCount = s.Read(buffer, 0, buffer.Length)))
            {
                sw.Write(buffer, 0, readCount);
            }
        }
    }
