    public static Bitmap ResizeImage(Bitmap imgToResize, Size size)
    {
        try
        {
            Bitmap b = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage((Image)b))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(imgToResize, 0, 0, size.Width, size.Height);
            }
            return b;
        }
        catch 
        { 
            Console.WriteLine("Bitmap could not be resized");
            return imgToResize; 
        }
    }
