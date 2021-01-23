    // Create a new image 50x50 in size
    using (var image = new Bitmap(50, 50))
    using (var gfx = Graphics.FromImage(image))
    {
        // Draw a line on this image from (0x0) to (50x50)
        gfx.DrawLine(new Pen(Color.Red), 0, 0, 50, 50);
        // save the resulting Graphics object to a new file
        using (var output = File.OpenWrite(@"c:\work\output.png"))
        {
            image.Save(output, ImageFormat.Png);
        }
    }
