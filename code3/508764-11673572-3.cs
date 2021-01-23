    private void MouseStuff(MouseEventArgs e) {
      if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
      {
        foreach (Squares point in mySquares) {
          if (point.Square.Contains(e.Location)) {
            if (e.Button == MouseButtons.Left) {
              Pencil(point);
            } else {
               Erase(point);
            }
          }
        }
        panelGrid.Invalidate();
      }
    }
