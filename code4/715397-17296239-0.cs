    private Bitmap CombineImages(Bitmap bmp_1, Bitmap bmp_2)
    {
        if (bmp_1.Width == bmp_2.Width)
        {
            int bmp_1_Height, bmpWidth, bmp_2_Height;
            bmpWidth = bmp_1.Width;
            bmp_1_Height = bmp_1.Height;
            bmp_2_Height = bmp_2.Height;
            Color c;
            bool notFound = false;
            int firstMatchedRow = 0;
            byte[,] bmp2_first2rows = new byte[3 * bmpWidth, 2];
            for (int b = 0; b < 2; b++)
            {
                for (int a = 0; a < bmpWidth; a++)
                {
                    c = bmp_2.GetPixel(a, b);
                    bmp2_first2rows[a * 3, b] = c.R;
                    bmp2_first2rows[a * 3 + 1, b] = c.G;
                    bmp2_first2rows[a * 3 + 2, b] = c.B;
                }
            }
            for (int y = 0; y < bmp_1_Height - 1; y++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int x = 0; x < bmpWidth; x++)
                    {
                        c = bmp_1.GetPixel(x, y + j);
                        if ((bmp2_first2rows[x * 3, j] == c.R) &&
                            (bmp2_first2rows[x * 3 + 1, j] == c.G) &&
                            (bmp2_first2rows[x * 3 + 2, j] == c.B))
                        {
                        }
                        else
                        {
                            notFound = true;
                            break;
                        }
                    }
                    if (notFound)
                    {
                        break;
                    }
                }
                if (!notFound)
                {
                    firstMatchedRow = y;
                    break;
                }
                else
                {
                    notFound = false;
                }
            }
            if (firstMatchedRow > 0)
            {
                Bitmap bmp = new Bitmap(bmpWidth, firstMatchedRow + bmp_2_Height);
                Graphics g = Graphics.FromImage(bmp);
                Rectangle RectDst = new Rectangle(0, 0, bmpWidth, firstMatchedRow);
                Rectangle RectSrc;
                g.DrawImage(bmp_1, RectDst, RectDst, GraphicsUnit.Pixel);
                RectDst = new Rectangle(0, firstMatchedRow, bmpWidth, bmp_2_Height);
                RectSrc = new Rectangle(0, 0, bmpWidth, bmp_2_Height);
                g.DrawImage(bmp_2, RectDst, RectSrc, GraphicsUnit.Pixel);
                return bmp;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }
