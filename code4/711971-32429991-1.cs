    rectf = new RectangleF(655, 460, 535, 90); //rectf for My Text
    using(Graphics g = Graphics.FromImage(myBitmap))
    {
    	//g.DrawRectangle(new Pen(Color.Red, 2), 655, 460, 535, 90); 
    	g.SmoothingMode = SmoothingMode.AntiAlias;
    	g.InterpolationMode = InterpolationMode.HighQualityBicubic;
    	g.PixelOffsetMode = PixelOffsetMode.HighQuality;
    	StringFormat sf = new StringFormat();
    	sf.Alignment = StringAlignment.Center;
    	sf.LineAlignment = StringAlignment.Center;
    	g.DrawString("My\nText", new System.Drawing.Font("Tahoma", 32, FontStyle.Bold), Brushes.Black, rectf, sf);
    }
