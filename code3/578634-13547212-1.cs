        private Bitmap RotateImage(Bitmap source, float angle)
        {
            if (angle == 0) return (Bitmap)source.Clone();
            Bitmap target;
            using (GraphicsPath path = new GraphicsPath())
            using (Matrix matrix = new Matrix())
            {
                path.AddRectangle(new RectangleF(0.0f, 0.0f, source.Width, source.Height));
                matrix.Rotate(angle);
                RectangleF rect = path.GetBounds(matrix);
                
                target = new Bitmap((int)Math.Round(rect.Width), (int)Math.Round(rect.Height));
                target.SetResolution(source.HorizontalResolution, source.VerticalResolution);
                using (Graphics g = Graphics.FromImage(target))
                {
                    g.TranslateTransform(-rect.X, -rect.Y);
                    g.RotateTransform(angle);
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImageUnscaled(source, 0, 0);
                }
            }
            return target;
        }
