    using (Graphics gr = Graphics.FromImage(cpy))
    {
        gr.Clear(Color.Transparent);
        gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
        gr.DrawImage(img, new Rectangle(0, 0, nnx, nny), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
    }
