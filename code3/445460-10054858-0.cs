    class ProcessingImage
        {         
            public Bitmap GetDifference(Bitmap bm1, Bitmap bm2)
            {            
                if (bm1.Size != bm2.Size)
                    throw new ArgumentException("Images must have one size");
                
                var resultImage = new Bitmap(bm1.Width, bm1.Height);
    
                using (Graphics g = Graphics.FromImage(resultImage))
                    g.Clear(Color.Transparent);
    
                int min_height = int.MaxValue;
                int min_width = int.MaxValue;
                int max_height = -1;
                int max_width = -1;
    
                for (int w = 0; w < bm1.Width; w++)
                    for (int h = 0; h < bm1.Height; h++)
                    {
                        var bm2Color = bm2.GetPixel(w, h);
                        if (IsColorsDifferent(bm1.GetPixel(w, h), bm2Color))
                        {
                            resultImage.SetPixel(w, h, bm2Color);
                            if (h < min_height) min_height = h;
                            if (w < min_width) min_width = w;
                            if (h > max_height) max_height = h;
                            if (w > max_width) max_width = w;
                        }                    
                    }
    
                max_height = max_height + 1;    //Needed for get valid max height point, otherwise we lost one pixel.
                max_width = max_width + 1;      //Needed for get valid max width point, otherwise we lost one pixel.
    
    
                // Calculate original size for image without alpha chanel.
    
                int size_h = max_height - min_height;
                int size_w = max_width - min_width;
    
                var resizeImage = new Bitmap(size_w, size_h); // Creaete bitmap with new size.
    
                for (int w = 0; w < resultImage.Width; w++)
                    for (int h = 0; h < resultImage.Height; h++)
                    {
                        var color = resultImage.GetPixel(w, h);
                        if (color.A != 0)
                        {
                            // Move each pixels at a distance calculate before.
                            int x = w - min_width;
                            int y = h - min_height;
                            resizeImage.SetPixel(x, y, color);
                        }
                    }           
    
                return resizeImage;
            }
            
            bool IsColorsDifferent(Color c1, Color c2)
            {
                return c1 != c2;
            }
        }
