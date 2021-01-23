        private void GetPixels()
        {
            Bitmap b = new Bitmap(pictureBox1.Image);
            List<Color> colorList = new List<Color>
            {
            };
            for (int y = 0; y < b.Height; y++)
            {
                for (int x = 0; x < b.Width; x++)
                {
                    colorList.Add(b.GetPixel(x, y));
                }
            }
        }
