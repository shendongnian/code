    protected void gridViewReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                decimal cellValue = 0.0m;
                DataRow dr = ((DataRowView)e.Row.DataItem).Row;
                if (dr[urs_cell_index] != null)
                {
                    if (decimal.TryParse(dr[urs_cell_index].ToString(), out cellValue))
                    {
                        e.Row.Cells[urs_cell_index].HorizontalAlign = HorizontalAlign.Right;
                    }
                    else
                    {
                        e.Row.Cells[urs_cell_index].HorizontalAlign = HorizontalAlign.Left;
                    }
                }
            }
        }
