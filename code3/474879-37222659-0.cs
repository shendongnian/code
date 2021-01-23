    if (Menu != null && mevent.Button == MouseButtons.Left)
    {
        if (mevent.Location.X >= this.Width - 14)
        {
            System.Drawing.Point menuLocation;
            if (ShowMenuUnderCursor)
            {
                menuLocation = mevent.Location; 
            }
            else
            {
                menuLocation = new System.Drawing.Point(0, Height);
            }
            Menu.Show(this, menuLocation);
        }
    }
