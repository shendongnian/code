    public Rectangle ManipulateRectangle(Rectangle rect) 
    {
        var newRectangle = new Rectangle();
        newRectangle.SetWidth(rect.GetHeight()); //ex manipulation
        return newRectangle;
    }
