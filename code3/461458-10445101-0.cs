	var bmp = new Bitmap((int)width, (int)height);
	var graph = Graphics.FromImage(bmp);
    // uncomment for higher quality output
	//graph.InterpolationMode = InterpolationMode.High;
	//graph.CompositingQuality = CompositingQuality.HighQuality;
	//graph.SmoothingMode = SmoothingMode.AntiAlias;
	graph.FillRectangle(brush, new RectangleF(0, 0, width, height));
	graph.DrawImage(image, new Rectangle(0, 0, (int)(image.Width * scale), (int)(image.Height * scale)));
