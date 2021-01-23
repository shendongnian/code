            static void Main(string[] args)
        {
            string filepath = @"C:\SomePath\SomeFile.JPG";
            Bitmap image1 = new Bitmap(System.Drawing.Image.FromFile(filepath, true));
            string filepath2 = @"C:\temp\myFile.txt";
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filepath2))
            {
                for (int y = 0; y < image1.Height; y++)
                {
                    for (int x = 0; x < image1.Width; x++)
                    {
                        Color pixelColor = image1.GetPixel(x, y);
                        byte r = pixelColor.R;
                        byte g = pixelColor.G;
                        byte b = pixelColor.B;
                        string pixData = String.Format("({0},{1},{2})", new object[] { r, g, b });
                        file.WriteLine(pixData);
                    }
                }
            }
        }
