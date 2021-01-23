    // START: Creating a red graphic instead of image
    Bitmap b = new Bitmap(16, 16);
    
    Graphics g = Graphics.FromImage(b);
    g.Clear(Color.Transparent);
    SolidBrush sb = new SolidBrush(Color.Red);
    g.FillEllipse(sb, 0, 0, 16, 16);
    // END: Creating a red graphic instead of image
    m_notifyicon.Visible = true;
    m_notifyicon.Icon = Icon.FromHandle(b.GetHicon());
