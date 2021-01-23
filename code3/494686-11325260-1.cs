    private Rectangle _hotspot = new Rectangle(20, 30, 10, 10);
    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            if (_hotspot.Contains(e.Location))
            {
                // respond to the mouse being in the hotspot
            }
        }
    }
