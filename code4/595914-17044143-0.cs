    `
            private double[] GetImageData(Bitmap bmp)
            {
            double[] imageData = null;
            //Make the image grayscale
            Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
            bmp = filter.Apply(bmp);
            //Binarize the image
            AForge.Imaging.Filters.Threshold thFilter = new AForge.Imaging.Filters.Threshold(128);
            thFilter.ApplyInPlace(bmp);
            int height = bmp.Height;
            int width = bmp.Width;
            imageData = new double[height * width];
            int imagePointer = 0;
            System.Diagnostics.Debug.WriteLine("Height : " + height);
            System.Diagnostics.Debug.WriteLine("Width  : " + width);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    System.Diagnostics.Debug.Write(string.Format("({0}  , {1})     Color : {2}\n", i, j, bmp.GetPixel(i, j)));
                    //Identify the black points of the image
                    if (bmp.GetPixel(i, j) == Color.FromArgb(255, 0,  0, 0))
                    {
                        imageData[imagePointer] = 1;
                    }
                    else
                    {
                        imageData[imagePointer] = 0;
                    }
                    imagePointer++;
                }
                System.Diagnostics.Debug.WriteLine("");
            }
            System.Diagnostics.Debug.WriteLine("Bits  : " + imagePointer );
            return imageData;
        }`
