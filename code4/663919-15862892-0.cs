    string outputFileName = "...";
    using (MemoryStream memory = new MemoryStream())
    {
        using (FileStream fs = new FileStream(outputFileName, FileMode.Create, FileAccess.ReadWrite))
        {
            thumbBMP.Save(memory, ImageFormat.Jpeg);
            byte[] bytes = memory.ToArray();
            fs.Write(bytes, 0, bytes.Length);
        }
    }
