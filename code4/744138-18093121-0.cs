    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    namespace BmpFile
    {
        public class BmpTest
        {
            private const int PixelSize = 4;
            public static long Test(int GridX, int GridY, int SquareSize, Rectangle[][] Rect)
            {
                Bitmap bmp = new Bitmap(GridX * SquareSize, GridY * SquareSize, PixelFormat.Format32bppArgb);
                BitmapData bmd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                                              System.Drawing.Imaging.ImageLockMode.ReadWrite,
                                              bmp.PixelFormat);
                int Stride = bmd.Stride;
                int Height = bmd.Height;
                int Width = bmd.Width;
                int RectFirst = Rect.GetUpperBound(0);
                int RectSecond;
                int Offset1, Offset2, Offset3;
                int i, j, k, l, w, h;
                int FullRow = SquareSize * Stride;
                int FullSquare = SquareSize * PixelSize;
                var sw = System.Diagnostics.Stopwatch.StartNew();
                unsafe
                {
                    byte* row = (byte*)bmd.Scan0;
                    //draw all rectangles
                    for (i = 0; i <= RectFirst; ++i)
                    {
                        Offset1 = ((i / GridX) * FullRow) + ((i % GridX) * FullSquare) + 3;
                        RectSecond = Rect[i].GetUpperBound(0);
                    
                        for (j = 0; j <= RectSecond; ++j)
                        {
                            Offset2 = Rect[i][j].X * PixelSize + Rect[i][j].Y * Stride;
                            w=Rect[i][j].Width;
                            h=Rect[i][j].Height;
                            for (k = 0; k <= w; ++k)
                            {
                                Offset3 = k * PixelSize;
                                for (l = 0; l <= h; ++l)
                                {
                                    row[Offset1 + Offset2 + Offset3 + (l * Stride)] = 255;
                                }
                            }
                        }
                    }
                    //invert color
                    for (int y = 0; y < Height; y++)
                    {
                        Offset1 = (y * Stride) + 3;
                        for (int x = 0; x < Width; x++)
                        {
                            if (row[Offset1 + x * PixelSize] == 255)
                            {
                                row[Offset1 + x * PixelSize] = 0;
                            }
                            else
                            {
                                row[Offset1 + x * PixelSize] = 255;
                            }
                        }
                    }
                }
                sw.Stop();
                bmp.UnlockBits(bmd);
                bmp.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\test.png", ImageFormat.Png);
                bmp.Dispose();
                return sw.ElapsedMilliseconds;
            }
        }
    }
