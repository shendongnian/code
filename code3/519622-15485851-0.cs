        try
        {
            string fn = Path.Combine(Path.GetTempPath(), "Error_screen.png");
            Bitmap bmp = new Bitmap(internalBrowser.Width, internalBrowser.Height);
            // In order to use DrawToBitmap, the image must have an INITIAL image. 
            // Not sure why. Perhaps it uses this initial image as a mask??? Dunno.
            using (Graphics G = Graphics.FromImage(bmp))
            {
                G.Clear(Color.Black);
            }
            internalBrowser.DrawToBitmap(bmp, new Rectangle(0, 0, 
                        internalBrowser.Width, internalBrowser.Height));
            bmp.Save(fn, ImageFormat.Png);
        }
        catch
        {
            // handle exceptions here.
            return "";
        }
