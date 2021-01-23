        public static void Rotate(string fileName,RotateFlipType rft, string targetMimeType)
        {
            ImageCodecInfo imageCodecInfo = ImageCodecInfo.GetImageEncoders().Single(i => i.MimeType == targetMimeType);
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, 100L);
            using( Image im = Image.FromFile(fileName, true))
            {
                im.RotateFlip(rft);
                im.Save("rotated_"+fileName, imageCodecInfo, encoderParams);
            }
        }
