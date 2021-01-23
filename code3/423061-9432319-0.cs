    var jpegQuality = 50;
    var image = Image.FromFile(@"C:\Users\Public\Pictures\Sample Pictures\Tulips.jpg");
    var jpegEncoder = ImageCodecInfo.GetImageDecoders()
      .First(c => c.FormatID == ImageFormat.Jpeg.Guid);
    var encoderParameters = new EncoderParameters(1);
    encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, jpegQuality);
    image.Save(
      @"C:\Users\Public\Pictures\Sample Pictures\Tulips2.jpg",
      jpegEncoder,
      encoderParameters
    );
