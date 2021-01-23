    using System;
    using System.Drawing;
    namespace Test
    {
        class Program
        {
            static void Main()
            {
                var bitmap = GenerateMaskBitmap(100, 100);
                TestMaskBitmap(bitmap);
            }
            const int CircleDiameter = 10;
            const int CircleSpacing = 10;
            static Bitmap GenerateMaskBitmap(int width, int height)
            {
                Bitmap maskBitmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                using (Graphics g = Graphics.FromImage(maskBitmap))
                {
                    Brush brush = Brushes.Black;
                    for (int y = 0; y < maskBitmap.Height; y += CircleSpacing)
                    {
                        for (int x = 0; x < maskBitmap.Width; x += CircleSpacing)
                        {
                            g.FillEllipse(brush, x, y, CircleDiameter, CircleDiameter);
                        }
                    }
                    g.Flush();
                }
                return maskBitmap;
            }
            static void TestMaskBitmap(Bitmap maskBitmap)
            {
                for (int y = 0; y < maskBitmap.Height; y++)
                {
                    for (int x = 0; x < maskBitmap.Width; x++)
                    {
                        Color tempColor = maskBitmap.GetPixel(x, y);
                        if (tempColor.ToArgb() != 0)
                            throw new Exception("It works!");
                    }
                }
            }
        }
    }
