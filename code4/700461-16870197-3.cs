    public static class FormExtentions
    {
        public static void TakeScreenshot(this Form form, string filename, System.Drawing.Imaging.ImageFormat format)
        {
            if (form == null)
               throw new ArgumentNullException("form");
            if (filename == null)
               throw new ArgumentNullException("filename");
            if (format == null)
               throw new ArgumentNullException("format");
            using (var bmp = new System.Drawing.Bitmap(form.Width, form.Height))
            {
                form.DrawToBitmap(bmp, new Rectangle(0, 0, form.Width, form.Height));
                bmp.Save("formScreenshot.bmp"); //or change another format.
            }
        }
    }
