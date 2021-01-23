    protected override void OnPaint(PaintEventArgs e)
    {
        Rectangle bounds = new Rectangle(0, 0, Width, Height);
        int alpha = (opacity * 255) / 100;
        using (Graphics graphics = e.Graphics)
        using (BufferedGraphicsContext bufferContext = new BufferedGraphicsContext())
        using (BufferedGraphics bufferedGraphics = bufferContext.Allocate(graphics, bounds))
        {
            using (Brush bckColor = new SolidBrush(Color.FromArgb(alpha, BackColor)))
            {
                if (BackColor != Color.Transparent)
                    bufferedGraphics.Graphics.FillRectangle(bckColor, bounds);
            }
            ColorMatrix colorMatrix = new ColorMatrix();
            colorMatrix.Matrix33 = (float)alpha / 255;
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            if (BackgroundImage != null)
                bufferedGraphics.Graphics.DrawImage(BackgroundImage, bounds, 0, 0, Width, Height, GraphicsUnit.Pixel, imageAttr);
            if (Text != string.Empty)
            {
                using (Brush txtBrush = new SolidBrush(Color.FromArgb(alpha, ForeColor)))
                {
                    bufferedGraphics.Graphics.DrawString(Text, Font, txtBrush, 5, 5);
                }
            }
            bufferedGraphics.Render();
        }
    }
