    private void panel_MouseDown(object sender, MouseEventArgs e)
    {
        var cursorRectangle = new Rectangle(e.Location, new Size(1, 1)); // We need rectangle for Intersect method.
        var copyOfRegion = _region.Clone(); // Don't break original region.
        copyOfRegion.Intersect(cursorRectangle); // Check whether cursor is in complex shape.
        Debug.WriteLine(copyOfRegion.IsEmpty(_panelGraphics) ? "Miss" : "In");
    }
