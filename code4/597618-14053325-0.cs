    static void DrawControlToImage(Control ctrl, Image img) {
        Rectangle sourceRect = ctrl.ClientRectangle;
        Size targetSize = new Size(img.Width, img.Height);
        using(Bitmap tmp = new Bitmap(sourceRect.Width, sourceRect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)) {
            ctrl.DrawToBitmap(tmp, sourceRect);
            using(Graphics g = Graphics.FromImage(img)) {
                g.DrawImage(tmp, new Rectangle(Point.Empty, targetSize));
            }
        }
    }
