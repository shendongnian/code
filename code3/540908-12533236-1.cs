    var image = Image.FromFile(@"C:\Sample.tiff");
    
    var encoders = ImageCodecInfo.GetImageEncoders();
    var imageCodecInfo = encoders.FirstOrDefault(encoder => encoder.MimeType == "image/tiff");
    
    if (imageCodecInfo == null)
    {
        return;
    }
    
    var imageEncoderParams = new EncoderParameters(1);
    imageEncoderParams.Param[0] = new EncoderParameter(Encoder.Quality, 100L);
    image.Save(@"C:\Sample.png", imageCodecInfo, imageEncoderParams);
