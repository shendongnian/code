    // Form myFrm
    Rectangle r = new Rectangle();
    foreach (Screen s in Screen.AllScreens)
    {
       if ( s != Screen.CurrentScreen ) // Blackout only the secondary screens
             r = Rectangle.Union(r, s.Bounds);
    }
    myFrm.Top = r.Top;
    myFrm.Left = r.Left;
    myFrm.Width = r.Width;
    myFrm.Height = r.Height;
    myFrm.TopMost = true; // This will bring your window in front of all other windows including the taskbar
