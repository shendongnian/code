    public static void SaveToPNG(Bitmap SourceImage, string DestinationPath)
    {
        SourceImage.Save(DestinationPath, ImageFormat.Png);
        CompressFile(DestinationPath, true);
    }
    
    private static string CompressFile(string SourceFile, bool DeleteSourceFile)
    {
        string TargetZipFileName = Path.ChangeExtension(SourceFile, ".zip");
    
        using (ZipArchive archive = ZipFile.Open(TargetZipFileName, ZipArchiveMode.Create))
        {
            archive.CreateEntryFromFile(SourceFile, Path.GetFileName(SourceFile),CompressionLevel.Optimal);
        }
    
        if(DeleteSourceFile == true)
        {
            File.Delete(SourceFile);
        }
        return TargetZipFileName;
    }
