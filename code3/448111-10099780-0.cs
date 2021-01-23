    void f6(Graphics g) 
    { 
        var img = Image.FromFile(@"d:\small3.png"); 
        var srcRect = new Rectangle(0, 0, img.Width, img.Height); 
        int factor = 400; 
        var destRect = new Rectangle(0, 0, img.Width * factor, img.Height * factor);
        g.ImterpolatonMode = InterpolationMode.NearestNeighbor;
        g.DrawRectangle(new Pen(Color.Blue), destRect); 
        g.DrawImage(img, destRect, srcRect, GraphicsUnit.Pixel); 
    } 
