    public bool IsAlphaBitmap(ref System.Drawing.Imaging.BitmapData BmpData)
    {
    	int h = BmpData.Height;
    	int w = BmpData.Width;
    	byte[] Bytes = new byte[h * BmpData.Stride];
    	Marshal.Copy(BmpData.Scan0, Bytes, 0, Bytes.Length);
    	for (p = 0; p < Bytes.Length; p += 4) {
    		if (Bytes(p + 3) != 0) return true;
    	}
    	return false;
    }
