    protected static Bitmap CropImage(Bitmap src, Vector2[] rect)
    {
        var width = (rect[1] - rect[0]).Length;
        var height = (rect[3] - rect[0]).Length;
        var result = new Bitmap(M2.Round(width), M2.Round(height));
        using (Graphics g = Graphics.FromImage(result))
        {
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            using (Matrix mat = new Matrix())
            {
                var rot = -Math.Atan2(rect[1].Y - rect[0].Y, rect[1].X - rect[0].X) * M2.RadToDeg;
                    
                mat.Translate(-rect[0].X, -rect[0].Y);
                mat.RotateAt((float)rot, rect[0].ToPointF());
                      
                g.Transform = mat;
                g.DrawImage(src, new Point(0, 0));
            }
        }
        return result;
    }
