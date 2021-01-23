    foreach (string file in Directory.EnumerateFiles(path, "*.xml"))
    {
        byte[] byteArray = System.IO.File.ReadAllBytes(file);
        channel.UploadTransaction(file, 27, byteArray);
    }
