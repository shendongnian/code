    public static void ResizeImageFreeSize(string OriginalFile, string NewFile, int MinWidth, int MinHeight, string FileExtension)
    {
    	var NewHeight = MinHeight;
        var NewWidth = MinWidth;		
    	var OriginalImage = Image.FromFile(OriginalFile);
    
        if (OriginalImage.Width < MinWidth || OriginalImage.Height < MinHeight)
            throw new Exception(String.Format("Invalid Image Dimensions, please upload an image with minmum dimensions of {0}x{1}px", MinWidth.ToString(), MinHeight.ToString()));
    	
        // If the image dimensions are the same then make the new dimensions the largest of the two mins.
        if (OriginalImage.Height == OriginalImage.Width)
    	    NewWidth = NewHeight = (MinWidth > MinHeight) ? MinWidth : MinHeight;
        else
        {
            if (MinWidth > MinHeight)
                NewHeight = (int)(OriginalImage.Height * ((float)MinWidth / (float)OriginalImage.Width));
            else
                NewWidth  = (int)(OriginalImage.Width * ((float)MinHeight / (float)OriginalImage.Height));
        }
    	
    	// Just resample the Original Image into a new Bitmap
    	var ResizedBitmap = new System.Drawing.Bitmap(OriginalImage, NewWidth, NewHeight);
    	
    	// Saves the new bitmap in the same format as it's source image
        FileExtension = FileExtension.ToLower().Replace(".","");
    
        ImageFormat Format = null;
        switch (FileExtension)
        {
            case "jpg":
                Format = ImageFormat.Jpeg;
                break;
            case "gif":
                Format = ImageFormat.Gif;
                break;
            case "png":
                Format = ImageFormat.Png;
                break;
            default:
                Format = ImageFormat.Png;
                break;
        }
    
        ResizedBitmap.Save(NewFile, Format);
           	
    	
        // Clear handle to original file so that we can overwrite it if necessary
        OriginalImage.Dispose();
        ResizedBitmap.Dispose();
    }
