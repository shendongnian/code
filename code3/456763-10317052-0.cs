       public void ResizeImage(string sImageFile, decimal dWidth, decimal dHeight, string sOutputFile)
        {
            Image oImg = Bitmap.FromFile(sImageFile);
            Bitmap oBMP = new Bitmap(decimal.ToInt16(dWidth), decimal.ToInt16(dHeight));
    
            Graphics g = Graphics.FromImage(oBMP);
            g.PageUnit = pgUnits;
            g.SmoothingMode = psMode;
            g.InterpolationMode = piMode;
            g.PixelOffsetMode = ppOffsetMode;
    
            g.DrawImage(oImg, 0, 0, decimal.ToInt16(dWidth), decimal.ToInt16(dHeight));
    
            ImageCodecInfo oEncoder = GetEncoder();
            EncoderParameters oENC = new EncoderParameters(1);
    
            oENC.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, plEncoderQuality);
    
            oImg.Dispose();
    
            oBMP.Save(sOutputFile, oEncoder, oENC);
            g.Dispose();
    
        }
