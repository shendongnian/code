            RGBImage image = _currentImage as RGBImage;
            int height = image.Height;
            int width = image.Width;
            
            //transform the 1D array of byte into MxNx3 matrix 
            
            byte[ , , ] RGBByteImage = new byte[3,height, width];
            
            if (image[0].Bpp > 16)
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0, k = 0; k < width; j = j + 3, k++)
                    {
                        RGBByteImage[0, i, k] = image[0].Data[i * width + j];
                        RGBByteImage[1, i, k] = image[0].Data[i * width + j + 1];
                        RGBByteImage[2, i, k] = image[0].Data[i * width + j + 2]; 
                    }
                }
            }
            MWNumericArray matrix = null;
            matrix = new MWNumericArray(MWArrayComplexity.Real, MWNumericType.Int8, 3,height, width);
            matrix = RGBByteImage;
