        public WriteableBitmap ToBitmap()
        {
            const int BLACK = 0;
            const int WHITE = -1;
            sbyte[][] array = Array;
            int width = Width;
            int height = Height;
            var pixels = new byte[width*height];
            var bmp = new WriteableBitmap(width, height);
            for (int y = 0; y < height; y++)
            {
                int offset = y*width;
                for (int x = 0; x < width; x++)
                {
                    int c = array[y][x] == 0 ? BLACK : WHITE;
                    bmp.SetPixel(x, y, c);
                }
            }
            //Return the bitmap
            return bmp;
        }
