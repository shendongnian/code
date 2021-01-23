    bool ImagesAreDifferent(Image img1, Image img2)
    {
        Bitmap bmp1 = new Bitmap(img1);
        Bitmap bmp2 = new Bitmap(img2);
        bool different = false;
        if (bmp1.Width == bmp2.Width && bmp1.Height == bmp2.Height)
        {
            for (int i = 0; i < bmp1.Width; i++)
            {
                for (int j = 0; j < bmp1.Height; j++)
                {
                    Color col1 = bmp1.GetPixel(i, j);
                    Color col2 = bmp2.GetPixel(i, j);
                    if (col1 != col2)
                    {
                        i = bmp1.Width + 1;
                        different = true;
                        break;
                    }
                }
            }
        }    
        return different;
    }
