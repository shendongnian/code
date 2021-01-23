    public void UpAndUnder(Button cBtn1, Button cBtn2)
    {
        if (cBtn1.Location == cBtn2.Location.Y)
        {                
            Point oldPoint = new Point(cBtn1.Location.X, cBtn1.Location.Y);
            cBtn1.Location = new Point(cBtn2.Location.X, cBtn2.Location.Y);
            cBtn2.Location = oldPoint;
        }
    }
