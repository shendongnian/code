    public static Bitmap ScreenShotaControl(Control aControl)
            {
                try
                {
                    Bitmap bmp = new Bitmap(aControl.Width, aControl.Height);
                    aControl.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    return bmp;
                }
                catch (Exception)
                {
    
                    throw;
                }
            }
