	using (MemoryStream ms = new MemoryStream())
	{
		bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
		byte[] buffer = ms.GetBuffer();
		HttpContext.Current.Response.OutputStream.Write(buffer, 0, buffer.Length);
		HttpContext.Current.Response.Flush();
	}
