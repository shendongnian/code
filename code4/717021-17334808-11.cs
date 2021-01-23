    byte[] results;
    using (MemoryStream ms = new MemoryStream())
    {
        ImageCodecInfo codec = ImageCodecInfo.GetImageEncoders().FirstOrDefault(c => c.FormatID == ImageFormat.Jpeg.Guid);
        EncoderParameters jpegParms = new EncoderParameters(1);
        jpegParms.Param[0] = new EncoderParameter(Encoder.Quality, 95L);
        newImage.Save(ms, codec, jpegParms);
        results = ms.ToArray();
    }
