       private void SaveJPGWithCompressionSetting(Image image, string szFileName, long lCompression)
        {
                try
                {
                    EncoderParameters eps = new EncoderParameters(1);
                    eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, lCompression);
                    ImageCodecInfo ici = GetEncoderInfo("image/jpeg");
                    image.Save(szFileName, ici, eps);
                }
}
