    public Color currentColor;
    private void ColorPickMouseDown(object sender, MouseEventArgs e)
    {
        Panel pnlSender = (Panel)sender;                   
        currentColor = pnlSender.BackColor;
    }
    private void panelTarget_MouseMove(object sender, MouseEventArgs e)
    {
        //the mouse button is released
        if (SortMouseLocation == Point.Empty)
        {
            Panel pnl = (Panel)sender;
            pnl.BackColor = currentColor;
        }
    }
