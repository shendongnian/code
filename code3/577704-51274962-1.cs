    /// <summary>
    /// Vertically flips a monochrome bitmap in-place
    /// </summary>
    /// <param name="bmp">Monochrome bitmap to flip</param>
    public static void RotateNoneFlipYMono(Bitmap bmp)
    {
    	if (bmp == null || bmp.PixelFormat != PixelFormat.Format1bppIndexed)
    		throw new InvalidValueException();
    
    	var height = bmp.Height;
    	var width = bmp.Width;
    	// width in dwords
    	var stride = (width + 31) >> 5;
    	// total image size
    	var size = stride * height;
    	// alloc storage for pixels
    	var bytes = new int[size];
    
    	// get image pixels
    	var rect = new Rectangle(Point.Empty, bmp.Size);            
    	var bd = bmp.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format1bppIndexed);            
    	Marshal.Copy(bd.Scan0, bytes, 0, size);
    
    	// flip by swapping dwords
    	int halfSize = size >> 1;
    	for (int y1 = 0, y2 = size - stride; y1 < halfSize; y1 += stride, y2 -= stride)
    	{
    		int end = y1 + stride;
    		for (int x1 = y1, x2 = y2; x1 < end; x1++, x2++)
    		{
    			bytes[x1] ^= bytes[x2];
    			bytes[x2] ^= bytes[x1];
    			bytes[x1] ^= bytes[x2];
    		}
    	}
    
    	// copy pixels back
    	Marshal.Copy(bytes, 0, bd.Scan0, size);
    	bmp.UnlockBits(bd);
    }
