    byte[] data;
    using (Image image = Image.FromFile(@"C:\test\test.jpg"))
    {
    	using (MemoryStream m = new MemoryStream())
    	{
    		image.Save(m, image.RawFormat);
    		data = m.ToArray();
    	}
    }
    
    FTPHelper ftpHelper = new FTPHelper("ftp://localhost", "test", "test");
    ftpHelper.Upload(new MemoryStream(data), "test.jpeg");
