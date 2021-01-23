    var size = new Size(1000, 1000);
    
    using(var source = new Metafile("c:\\temp\\Month_Calendar.emf"))
    using(var target = new Bitmap(size.Width, size.Height))
    using(var g = Graphics.FromImage(target))
    {
    	g.DrawImage(source, 0, 0, size.Width, size.Height);
    	target.Save("c:\\temp\\Month_Calendar.png", ImageFormat.Png);
    }
