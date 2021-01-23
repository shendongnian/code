     public void Crop(Bitmap bm, int cropX, int cropY,int cropWidth,int cropHeight)
     {
           var rect = new System.Drawing.Rectangle(cropX,cropY,cropWidth,cropHeight);
    
           Bitmap newBm = bm.Clone(rect, bm.PixelFormat);
    
           newBm.Save("image2.jpg");
     }
