    private void dgTxSummary_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        Rectangle cellRect = dgTxSummary.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
        Point dgPos = dgTxSummary.Location;
        Point cellPos = new Point(dgPos.X + cellRect.X, dgPos.Y + cellRect.Y);
        DateTime dt = DateTime.Parse(row.Cells[e.ColumnIndex].FormattedValue.ToString());
        ShowDatePicker(cellPos, dt);
    }
