    namespace testimg
    {
        class doimg
        {
            public Bitmap picture()
            {
                int x, y;
                // some staffs to get a picture, so it's in bmp object now.
                // I added some color to the Bitmap so I could see if it was there or not
                // How ever you draw the Image just return the Bitmap to the calling function.
                Bitmap bmp = new Bitmap(200, 200, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                for (x = 0; x < 200; x++)
                    for (y = 0; y < 200; y++)
                        bmp.SetPixel(x, y, Color.Red);
                return bmp;
            }
        }
    }
