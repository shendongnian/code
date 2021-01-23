    private void Form1_LocationChanged(Object sender, EventArgs e)
    {
        if (MousePosition.X > 500 || MousePosition.Y > 500)
            Location = MousePosition;
        else
            Location = new Point(0, 0);
    }
