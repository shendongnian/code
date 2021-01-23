    foreach(string s in Directory.GetFiles(path, "*.xml"))
    {
         byte[] byteArray = System.IO.File.ReadAllBytes(s);
         channel.UploadTransaction(s, 27, byteArray);
    }
