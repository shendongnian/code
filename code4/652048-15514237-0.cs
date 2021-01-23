    Image image = /* ... */;
    using (Graphics g = Graphics.FromImage(image))
    {
        g.DrawLine(myPen, pointA, pointB);
    }
    picture1.Image = image;
    
