    // Form myFrm
    Rectangle r = new Rectangle();
    foreach (Screen s in Screen.AllScreens)
    {
       r = Rectangle.Union(r, s.Bounds);
    }
    myFrm.Top = r.Top;
    myFrm.Left = r.Left;
    myFrm.Width = r.Width;
    myFrm.Height = r.Height;
