    private Bitmap DrawRectangle(int x, int y)
        {
            Bitmap bmp = new Bitmap(x, y);
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                Rectangle ImageSize = new Rectangle(0,0,x,y);
                Pen WhitePen = new Pen(Brushes.White);
                graph.FillRectangle(Brushes.White, ImageSize);
            }
            return bmp;
        }
