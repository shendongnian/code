    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    
    static class WPFGlyphToGDIPBitmap
    {
    	public static System.Drawing.Bitmap GetBitmapOfChar(GlyphTypeface gt, _
                                                            char c, _
                                                            double ptSize, _
                                                            float dpi)
    	{
    
    		ushort ci = 0;
    		if (!gt.CharacterToGlyphMap.TryGetValue(Strings.AscW(c), ci)) {
    			if (!gt.CharacterToGlyphMap.TryGetValue(Strings.Asc(c), ci))
    	                return null;
    		}
    
    		Geometry geo = gt.GetGlyphOutline(ci, ptSize, ptSize);
    		GeometryDrawing gDrawing = new GeometryDrawing(System.Windows.Media.Brushes.Black, null, geo);
    		DrawingImage geoImage = new DrawingImage(gDrawing);
    		geoImage.Freeze();
    
    		DrawingVisual viz = new DrawingVisual();
    		DrawingContext dc = viz.RenderOpen;
    
    		dc.DrawImage(geoImage, new Rect(0, 0, geoImage.Width, geoImage.Height));
    		dc.Close();
    
    		RenderTargetBitmap bmp = new RenderTargetBitmap(geoImage.Width, _
                                                            geoImage.Height, _
                                                            dpi, dpi, _
                                                            PixelFormats.Pbgra32);
    		bmp.Render(viz);
    
    		PngBitmapEncoder enc = new PngBitmapEncoder();
    		enc.Frames.Add(BitmapFrame.Create(bmp));
    
    		MemoryStream ms = new MemoryStream();
    		enc.Save(ms);
    		ms.Seek(0, SeekOrigin.Begin);
    
    		enc = null;
    		dc = null;
    		viz = null;
    
    		DisposeBitmap(bmp);
    
    		System.Drawing.Bitmap gdiBMP = new System.Drawing.Bitmap(ms);
    		ms.Dispose();
    
    		//gdiBMP.Save("c:\test.png", System.Drawing.Imaging.ImageFormat.Png)
    
    		return gdiBMP;
    
    	}
    
    }
    public static void DisposeBitmap(RenderTargetBitmap bmp)
    {
    	if (bmp != null) {
            bmp.Clear();
    	}
    	bmp = null;
    	GC.Collect();
    	GC.WaitForPendingFinalizers();
    }
