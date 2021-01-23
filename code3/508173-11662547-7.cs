    namespace testimg
    {
        static class  doimg
        {
            static Color[] clr = new Color[] { Color.Red, Color.Blue, Color.Black, Color.Violet, Color.Wheat };
            static  int count = 0;
            static  public Bitmap picture()
            {
            
                // some staffs to get a picture, so it's in bmp object now.
                Bitmap bmp = new Bitmap(200, 200, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                
                // Added some drawing to bitmap to test functionality
                Graphics gfx = Graphics.FromImage(bmp);
                gfx.DrawEllipse(new Pen(new SolidBrush(clr[count])),new Rectangle(0,0,199,199));
                
                gfx.Dispose();
            
                if (count >= 4)
                    count = 0;
                else
                    count += 1;
            
                return bmp;
            }
        }
    }
