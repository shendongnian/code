    void tableLayoutPanel_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
    {
        Graphics g = e.Graphics;
        Rectangle r = e.CellBounds;
        g.FillRectangle(GetBrushFor(e.Row, e.Column), r);
    }
    private Brush GetBrushFor(int row, int column)
    {
        if (row == 2 && column == 1)
            return Brushes.Red;
        // other logic
        // ...
        // return default Brush
    }
