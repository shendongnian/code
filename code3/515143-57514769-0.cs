    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    public byte[] ConvertImageToTiff(byte[] SourceImage)
    {
        //create a new byte array
        byte[] bin = new byte[0];
        //check if there is data
        if (SourceImage == null || SourceImage.Length == 0)
        {
            return bin;
        }
        //convert the byte array to a bitmap
        Bitmap NewImage;
        using (MemoryStream ms = new MemoryStream(SourceImage))
        {
            NewImage = new Bitmap(ms);
        }
        //set some properties
        Bitmap TempImage = new Bitmap(NewImage.Width, NewImage.Height);
        using (Graphics g = Graphics.FromImage(TempImage))
        {
            g.CompositingMode = CompositingMode.SourceCopy;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawImage(NewImage, 0, 0, NewImage.Width, NewImage.Height);
        }
        NewImage = TempImage;
        //save the image to a stream
        using (MemoryStream ms = new MemoryStream())
        {
            EncoderParameters encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, 80L);
            NewImage.Save(ms, GetEncoderInfo("image/tiff"), encoderParameters);
            bin = ms.ToArray();
        }
        //cleanup
        NewImage.Dispose();
        TempImage.Dispose();
        //return data
        return bin;
    }
    //get the correct encoder info
    public ImageCodecInfo GetEncoderInfo(string MimeType)
    {
        ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
        for (int j = 0; j < encoders.Length; ++j)
        {
            if (encoders[j].MimeType.ToLower() == MimeType.ToLower())
                return encoders[j];
        }
        return null;
    }
