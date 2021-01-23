        private void GenerateBitmapTiles() {
            Bitmap bitmap = new Bitmap(TilesetImageFile);
            bitmaps = new Bitmap[image.Width / 16, image.Height / 16];
            for (int x = 0; x < image.Width / 16; x++)
            {
                for (int y = 0; y < image.Height / 16; y++)
                {
                    bitmaps[x, y] = bitmap.Clone(new Rectangle(x * 16, y * 16, 16, 16), bitmap.PixelFormat);
                }
            }
            bitmap.Dispose();
        }
