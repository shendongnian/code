    for (int t = cx; t < mo; t += 20)
    {
        Control c = pic.GetChildAtPoint(new Point(cx, y));
        if (c == null)
        {
            pic.setChar(this.Image, t, yo);
            pic.Controls.Add(pic);
        }
    }
