    protected void Button2_Click(object sender, EventArgs e)
    {
    	//upload1.SaveAs(Server.MapPath("~/imgs/" + upload1.FileName).ToString());
    	//pbficheiro.ImageUrl = @"~/imgs/" + upload1.FileName;
    
    	Byte[] ba = new BinaryReader(upload1.PostedFile.InputStream).ReadBytes((Int32)upload1.PostedFile.InputStream.Length);
    	using (MemoryStream ms = new MemoryStream(ba, false))
    	{
    		System.Drawing.Image imgTmp = System.Drawing.Image.FromStream(ms);
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
    			pbficheiro.Image = System.Drawing.Image.FromStream(ms2);
    		}
    	}
    }
