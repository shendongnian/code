    Byte[] ba = new BinaryReader(upload1.PostedFile.InputStream).ReadBytes((Int32)upload1.PostedFile.InputStream.Length);
    using (MemoryStream ms = new MemoryStream(ba, false))
    {
    	Image imgTmp = Image.FromStream(ms);
    	Bitmap bm = new Bitmap(imgTmp.Width, imgTmp.Height);
    	Graphics g = Graphics.FromImage(bm);
    	g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
    	g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
    	g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
    	Rectangle rect = new Rectangle(0, 0, imgTmp.Width, imgTmp.Height);
    	g.DrawImage(imgTmp, rect, 0, 0, imgTmp.Width, imgTmp.Height, GraphicsUnit.Pixel);
    	using (MemoryStream ms2 = new MemoryStream())
    	{
    	    bm.Save(ms2, imgTmp.RawFormat);
              bm.Dispose();
              imgTmp.Dispose();
              if (WantAnImage)
                  return Image.FromStream(ms2);
              else (WantBytes)
                  return ms2.ToArray();
    	}
    }
