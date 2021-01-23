    using (FileStream fs = File.OpenRead(fileName)) {
    	using (StreamReader sr = new StreamReader(fs)) {
    		using (System.Drawing.Image img = System.Drawing.Image.FromStream(sr.BaseStream, true, false)) {
    			System.Drawing.Size sz = GetProportionalSize(maxSize, img.Size);
    			result = img.GetThumbnailImage(sz.Width, sz.Height, null, IntPtr.Zero);
    		}
    		sr.Close();
    	}
    	fs.Close();
    }
