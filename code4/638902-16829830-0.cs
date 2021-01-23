    private static byte[] getWebViewScreenshotAsBytes(ref WebView myWebView)
    {
	    using (System.IO.MemoryStream ms = new System.IO.MemoryStream()) {
		    using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(myWebView.Width, myWebView.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)) {
			    BitmapSurface bmpSurface = (BitmapSurface)myWebView.Surface;
			    BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);
			    bmpSurface.CopyTo(bmpData.Scan0, bmpSurface.RowSpan, 4, false, false);
			    bmp.UnlockBits(bmpData);
			    bmp.Save(ms, ImageFormat.Png);
		    }
		    return ms.ToArray();
	    }
    }
