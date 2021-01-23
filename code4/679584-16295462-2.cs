    foreach (string file in Directory.EnumerateFiles(path, "*.xml"))
    {
        byte[] byteArray = System.IO.File.ReadAllBytes(path);
        channel.UploadTransaction(path, 27, byteArray);
    }
