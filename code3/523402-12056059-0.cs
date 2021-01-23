        private byte[] ConvertToPNG(Bitmap bmp)
        {
        	MemoryStream ms = new MemoryStream();
        	// Save to memory using the Png format
        	bmp.Save (ms, ImageFormat.Png);
        	// read to end
        	byte[] bmpBytes = ms.GetBuffer();
        	bmp.Dispose();
        	ms.Close();
        	return bmpBytes;
        }
