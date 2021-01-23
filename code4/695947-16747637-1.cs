    private Bitmap SobelEdgeDetect(Bitmap original)
    {
        int width = original.Width;
        int height = original.Height;
        int BitsPerPixel = Image.GetPixelFormatSize(original.PixelFormat);
        int OneColorBits = BitsPerPixel / 8;
        BitmapData bmpData = original.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, original.PixelFormat);
        int position;
        int[,] gx = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
        int[,] gy = new int[,] { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };
        byte Threshold = 128;
        Bitmap dstBmp = new Bitmap(width, height, original.PixelFormat);
        BitmapData dstData = dstBmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, dstBmp.PixelFormat);
        unsafe
        {
            byte* ptr = (byte*)bmpData.Scan0.ToPointer();
            byte* dst = (byte*)dstData.Scan0.ToPointer();
            for (int i = 1; i < height - 1; i++)
            {
                for (int j = 1; j < width - 1; j++)
                {
                    int NewX = 0, NewY = 0;
                    for (int ii = 0; ii < 3; ii++)
                    {
                        for (int jj = 0; jj < 3; jj++)
                        {
                            int I = i + ii - 1;
                            int J = j + jj - 1;
                            byte Current = *(ptr + (I * width + J) * OneColorBits);
                            NewX += gx[ii, jj] * Current;
                            NewY += gy[ii, jj] * Current;
                        }
                    }
                    position = ((i * width + j) * OneColorBits);
                    if (NewX * NewX + NewY * NewY > Threshold * Threshold)
                        dst[position] = dst[position + 1] = dst[position + 2] = 255;
                    else
                        dst[position] = dst[position + 1] = dst[position + 2] = 0;
                }
            }
        }
        original.UnlockBits(bmpData);
        dstBmp.UnlockBits(dstData);
        return dstBmp;
    }
