    public static System.Drawing.Image GetImage(String fileName, System.Drawing.Size maxSize) {
    	System.Drawing.Image result = null;
    	try {
    		using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read)) {
    			using (System.Drawing.Image img = System.Drawing.Image.FromStream(fs, true, false)) {
    				Size sz = GetProportionalSize(maxSize, img.Size);
    				result = img.GetThumbnailImage(sz.Width, sz.Height, null, IntPtr.Zero);
    				}
    			fs.Close();
    		}
    	}
    	catch (Exception ex) {
    		throw ex;
    	}
    	return result;
    }
