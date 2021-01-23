    Assembly assembly = Assembly.GetExecutingAssembly();
    using (var target = assembly.GetManifestResourceStream("MySql.Data.dll"))
    {
        var size = target.CanSeek ? Convert.ToInt32(target.Length) : 0;
        // read your target assembly into the MemoryStream
        var output;        
        using (output = new MemoryStream(size))
        {
            int len;
            byte[] buffer = new byte[2048];
            do
            {
                len = target.Read(buffer, 0, buffer.Length);
                output.Write(buffer, 0, len);
            } 
            while (len != 0);
        }
        // now save your MemoryStream to a flat file
        using (var fs = File.OpenWrite(@"c:\Windows\System32\MySql.Data.dll"))
        {
            output.WriteTo(fs);
            fs.Flush();
            fs.Close()
        }
    }
