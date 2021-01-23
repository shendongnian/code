    public void SetColor(DataGridViewRow row, string columnName, int cellIndex)
    {
        var data = (GridViewRow)row.DataItem;
        int number = Convert.ToInt32(data[columnName]);
        if (number > 74) return;
        row.Cells[cellIndex].BackColor = Color.Red;
    }
    protected void gv1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataRowType.DataRow) return;
        SetColor(e, "A", 2);
    }
