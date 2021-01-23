    var qualityEncoder = Encoder.Quality;
    var quality = (long)<desired quality>;
    var ratio = new EncoderParameter(qualityEncoder, quality );
    var codecParams = new EncoderParameters(1);
    codecParams.Param[0] = ratio;
    var jpegCodecInfo = <one of the codec infos from ImageCodecInfo.GetImageEncoders() with mime type = "image/jpeg">;
    bmp.Save(fileName, jpegCodecInfo, codecParams); // Save to JPG
