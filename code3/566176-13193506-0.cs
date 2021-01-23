        Bitmap CreateBitmapImage(string text, Font textFont, SolidBrush textBrush)
        {
            Bitmap bitmap = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(bitmap);
            int intWidth = (int)graphics.MeasureString(text, textFont).Width;
            int intHeight = (int)graphics.MeasureString(text, textFont).Height;
            bitmap = new Bitmap(bitmap, new Size(intWidth, intHeight));
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphics.DrawString(text, textFont, textBrush,0,0);
            graphics.Flush();
            return (bitmap);
        }
