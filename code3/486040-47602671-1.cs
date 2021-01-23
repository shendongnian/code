    var bytes = File.ReadAllBytes("image.bmp");
    System.Windows.Controls.Image image = null;
    using (var stream = System.IO.MemoryStream(bytes))
    {
         image = System.Windows.Controls.Image.FromStream(stream); 
    }
    var brush = new System.Drawing.TextureBrush(image); // Exception Thrown!
