    //Load the bitmap
    Bitmap image = (Bitmap)Image.FromFile("image.png"); 
    
    //Get the bitmap data
    var bitmapData = image.LockBits (
    	new Rectangle (0, 0, image.Width, image.Height),
    	ImageLockMode.ReadWrite, 
    	image.PixelFormat
    );
    
    //Initialize a 2D array for all the image data
    byte[] imageBytes = new byte[bitmapData.Stride * image.Height];
    
    //Copy the bitmap data to the local array
    Marshal.Copy(bitmapData.Scan0,imageBytes,0,imageBytes.Length);
    
    //Unlock the bitmap
    image.UnlockBits(bitmapData);
    
    //Find pixelsize
    int pixelSize = Image.GetPixelFormatSize(image.PixelFormat);
    
    // An example on how to use the pixels, lets make a copy
    int x = 0;
    int y = 0;
    var bitmap = new Bitmap (image.Width, image.Height);
    //Loop pixels
    for(int i=0;i<imageBytes.Length;i+=pixelSize/8)
    {
    	//Copy the bits int
    	var pixelData = new byte[3];
    
    	Array.Copy(imageBytes,i,pixelData,0,3);
    
    	//Get the color of a pixel
    	var color = Color.FromArgb (pixelData [0], pixelData [1], pixelData [2]);
    
    
    	bitmap.SetPixel (x,y,color);
    
    	x++;
    	if( x >= 100)
    	{
    		x=0;
    		y++;
    	}
    
    }
    bitmap.Save ("image_copy.png");
