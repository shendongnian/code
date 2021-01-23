    private void newDataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (columnIndex != 1)
            return;
        Graphics g = e.Graphics;
        Rectangle rDraw = newDataGridView1.GetCellDisplayRectangle(columnIndex, rowIndex, true);
        e.Paint(e.CellBounds, e.PaintParts & ~DataGridViewPaintParts.ContentForeground);
        int y = rDraw.Y + 1;
        int midX = (int)(rDraw.Width / 2) + rDraw.X;
        g.DrawImage(imageList.Images[0], new Rectangle(midX - 6, y + 2, 12, 12));
        e.Handled = true;
    }
