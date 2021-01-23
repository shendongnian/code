    byte[] results;
    using (MemoryStream mso = new MemoryStream())
    {
        ImageCodecInfo codec = ImageCodecInfo.GetImageEncoders().FirstOrDefault(c => c.FormatID == ImageFormat.Jpeg.Guid);
        EncoderParameters jpegParms = new EncoderParameters(1);
        jpegParms.Param[0] = new EncoderParameter(Encoder.Quality, 95L);
        img.Save(ms, codec, jpegParms);
        results = ms.ToArray();
    }
