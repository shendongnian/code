    public static void ResizeImageFreeSize(string OriginalFile, string NewFile, int MinWidth, int MinHeight, string FileExtension)
    {
        var NewHeight = MinHeight;
        var NewWidth = MinWidth;
        // var OriginalImage = System.Drawing.Image.FromFile(OriginalFile); // THis statlement alon with generate error as file is locked so -->GDI+ keeps a lock on files from which an image was contructed.  To avoid the lock, construct the image from a MemorySteam:
        MemoryStream ms = new MemoryStream(File.ReadAllBytes(OriginalFile));
        var OriginalImage = System.Drawing.Image.FromStream(ms);
        if (OriginalImage.Width < MinWidth || OriginalImage.Height < MinHeight)
            throw new Exception(String.Format("Invalid Image Dimensions, please upload an image with minmum dimensions of {0}x{1}px", MinWidth.ToString(), MinHeight.ToString()));
        // If the image dimensions are the same then make the new dimensions the largest of the two mins.
        if (OriginalImage.Height == OriginalImage.Width)
            NewWidth = NewHeight = (MinWidth > MinHeight) ? MinWidth : MinHeight;
        else
        {
            if (MinWidth > MinHeight)
                NewHeight = (int)(OriginalImage.Height * ((float)MinWidth / (float)OriginalImage.Width));
            else
                NewWidth = (int)(OriginalImage.Width * ((float)MinHeight / (float)OriginalImage.Height));
        }
        // Just resample the Original Image into a new Bitmap
        var ResizedBitmap = new System.Drawing.Bitmap(OriginalImage, NewWidth, NewHeight);
        // Saves the new bitmap in the same format as it's source image
        FileExtension = FileExtension.ToLower().Replace(".", "");
        ImageFormat Format = null;
        switch (FileExtension)
        {
            case "jpg":
                Format = ImageFormat.Jpeg;
                Encoder quality = Encoder.Quality;
                var ratio = new EncoderParameter(quality, 100L);
                var codecParams = new EncoderParameters(1);
                codecParams.Param[0] = ratio;
                // NewImage.Save(NewFile, GetEncoder(ImageFormat.Jpeg), codecParams);
                ResizedBitmap.Save(NewFile, GetEncoder(ImageFormat.Jpeg), codecParams);
                break;
            case "gif":
                Format = ImageFormat.Gif;
                ResizedBitmap.Save(NewFile, Format);
                break;
            case "png":
                Format = ImageFormat.Png;
                ResizedBitmap.Save(NewFile, Format);
                break;
            default:
                Format = ImageFormat.Png;
                ResizedBitmap.Save(NewFile, Format);
                break;
        }
        //  ResizedBitmap.Save(NewFile, Format);
        // Clear handle to original file so that we can overwrite it if necessary
        OriginalImage.Dispose();
        ResizedBitmap.Dispose();
    }
    private static ImageCodecInfo GetEncoder(ImageFormat format)
    {
        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
        foreach (ImageCodecInfo codec in codecs)
            if (codec.FormatID == format.Guid)
                return codec;
        return null;
    }
