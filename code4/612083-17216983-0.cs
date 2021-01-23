    public Bitmap PrintScreen()
        {
            Rectangle rect = new Rectangle(Cursor.Position.X, Cursor.Position.Y, 500, 360);//Screen.PrimaryScreen.Bounds;
            int color = Screen.PrimaryScreen.BitsPerPixel;
            PixelFormat pFormat;
            switch (color)
            {
                case 8:
                case 16:
                    pFormat = PixelFormat.Format16bppRgb565;
                    break;
                case 24:
                    pFormat = PixelFormat.Format24bppRgb;
                    break;
                case 32:
                    pFormat = PixelFormat.Format32bppArgb;
                    break;
                default:
                    pFormat = PixelFormat.Format32bppArgb;
                    break;
            }
            Bitmap bmp = new Bitmap(rect.Width, rect.Height, pFormat);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, rect.Size);
            return bmp;
        }
