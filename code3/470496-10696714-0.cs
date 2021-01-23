    private void ExtractFromAssembly()
    {
        string strPath = Application.LocalUserAppDataPath + "\\MyFile.db";
        if (File.Exists(strPath)) return; // already exist, don't overwrite
        Assembly assembly = Assembly.GetExecutingAssembly();
        //In the next line you should provide NameSpace.FileName.Extension that you have embedded
        var input = assembly.GetManifestResourceStream("MyFile.db");
        var output = File.Open(strPath, FileMode.CreateNew);
        CopyStream(input, output);
        input.Dispose();
        output.Dispose();
        System.Diagnostics.Process.Start(strPath);
    }
    
    private void CopyStream(Stream input, Stream output)
    {
        byte[] buffer = new byte[32768];
        while (true)
        {
            int read = input.Read(buffer, 0, buffer.Length);
            if (read <= 0)
                return;
            output.Write(buffer, 0, read);
        }
    }
