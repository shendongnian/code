    private void Dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.ColumnIndex == 0 && e.RowIndex > -1)
        {
            Brush Brs= new SolidBrush(Color.FromName(Dgv[1, e.RowIndex].Value.ToString()));
            GraphicsExtensions.FillCircle(e.Graphics, Brs, e.CellBounds.Location.X + 5, e.CellBounds.Location.Y + 10, 5);
            e.Handled = true;                
        }
    }
