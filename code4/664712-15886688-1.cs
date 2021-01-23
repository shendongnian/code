    string outputFileName = "...";
    using (MemoryStream memory = new MemoryStream())
    {
        using (FileStream fs = new FileStream(outputFileName, FileMode.Create, FileAccess.ReadWrite))
        {
            tempImage.Save(memory, ImageFormat.Jpeg);
            // memory.ToStream(fs) // I think the same
            byte[] bytes = memory.ToArray();
            fs.Write(bytes, 0, bytes.Length);
        }
    }
