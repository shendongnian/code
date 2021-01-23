    private Bitmap DrawFilledRectangle(int x, int y)
        {
            Bitmap bmp = new Bitmap(x, y);
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                Rectangle ImageSize = new Rectangle(0,0,x,y);
                graph.FillRectangle(Brushes.White, ImageSize);
            }
            return bmp;
        }
