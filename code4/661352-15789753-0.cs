    var memoryStream = new System.IO.MemoryStream();
    using (var image = System.Drawing.Image.FromFile("myfile.tif"))
    	image.Save(memoryStream, ImageFormat.Png);
    
    return File(memoryStream, "image/png");
