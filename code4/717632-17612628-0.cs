    public BitmapSource ByteArrayToBitmap(byte[] byteArray) {
    	BitmapSource res;
    	try {
    		using (var stream = new MemoryStream(byteArray)) {
    			using (var bmp = new Bitmap(stream)) {
    				res = ToBitmap(bmp);
    			}
    		}
    	} catch {
    		res = null;
    	}
    	return res;
    }
    
    public BitmapSource ToBitmap(Bitmap bitmap) {
    	using (var stream = new MemoryStream()) {
    		bitmap.Save(stream, ImageFormat.Bmp);
    
    		stream.Position = 0;
    		var result = new BitmapImage();
    		result.BeginInit();		
    		result.CacheOption = BitmapCacheOption.OnLoad;
    		result.StreamSource = stream;
    		result.EndInit();
    		result.Freeze();
    		return result;
    	}
    }
