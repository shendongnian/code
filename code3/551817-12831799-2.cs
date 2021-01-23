    using (FileStream file = File.OpenRead(@"..\path\to\pdf\file.pdf")) // in file
    {
        var bytes = new byte[file.Length];
        file.Read(bytes, 0, bytes.Length);
        using (var pdf = new LibPdf(bytes))
        {
            byte[] pngBytes = pdf.GetImage(0,ImageType.PNG); // image type
            using (var outFile = File.Create(@"..\path\to\pdf\file.png")) // out file
            {
                outFile.Write(pngBytes, 0, pngBytes.Length);
            }
        }
    }
