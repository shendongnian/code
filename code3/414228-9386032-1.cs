    private void WriteTiffImage(string targetPath, System.Drawing.Image image)
    {
        Encoder        encoder  = Encoder.SaveFlag;
        ImageCodecInfo tiffInfo = ImageCodecInfo.GetImageEncoders()
                                  .Where(e => e.MimeType == "image/tiff")
                                  .FirstOrDefault();
        EncoderParameters encoderParams = new EncoderParameters(1);
        encoderParams.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.MultiFrame);
        image.Save(targetPath, tiffInfo, encoderParams);
        // close file
        encoderParams.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.Flush);
        image.SaveAdd(encoderParams);
    }
