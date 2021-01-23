    private void MouseStuff(MouseEventArgs e) {
      if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
      {
        foreach (Squares point in mySquares)
        {
            if (point.Square.Contains(e.Location))     // determine which point to use
            {
                if (e.Button == MouseButtons.Left)
                {
                    Pencil(point);        // left-click to fill color
                }
                else
                {
                    Erase(point);       // right-click to erase color
                }
            }
      }
      panelGrid.Invalidate();            // refreshes grid
    }
