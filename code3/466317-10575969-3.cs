    using (Graphics gr = Graphics.FromImage(cpy))
    {
        gr.Clear(Color.Transparent);
        gr.SmoothingMode = SmoothingMode.AntiAlias;
        gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
        gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
        gr.DrawImage(img, new Rectangle(0, 0, nnx, nny));
    }
