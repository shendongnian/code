    public static class FormExtentions
    {
        public static System.Drawing.Bitmap TakeScreenshot(this Form form)
        {
            if (form == null)
               throw new ArgumentNullException("form");
            form.DrawToBitmap(bmp, new Rectangle(0, 0, form.Width, form.Height));
            return bmp;
        }
        public static void SaveScreenshot(this Form form, string filename, System.Drawing.Imaging.ImageFormat format)
        {
            if (form == null)
               throw new ArgumentNullException("form");
            if (filename == null)
               throw new ArgumentNullException("filename");
            if (format == null)
               throw new ArgumentNullException("format");
            using (var bmp = form.TakeScreenshot())
            {
                bmp.Save(filename, format);
            }
        }
    }
