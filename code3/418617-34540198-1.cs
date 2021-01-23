    private static ImageCodecInfo __JPEGCodecInfo = null;
    private static ImageCodecInfo _JPEGCodecInfo
    {
        get
        {
            if (__JPEGCodecInfo == null)
            {
                __JPEGCodecInfo = ImageCodecInfo.GetImageEncoders().ToList().Find(delegate (ImageCodecInfo codec) { return codec.FormatID == ImageFormat.Jpeg.Guid; });
            }
            return __JPEGCodecInfo;
        }
    }
    public static void SaveToJPEG(Bitmap SourceImage, string DestinationPath, long Quality)
    {
        EncoderParameters parameters = new EncoderParameters(1);
    
        parameters.Param[0] = new EncoderParameter(Encoder.Quality, Quality);
    
        SourceImage.Save(DestinationPath, _JPEGCodecInfo, parameters);
    
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
