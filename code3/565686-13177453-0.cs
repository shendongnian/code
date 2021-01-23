     protected void GridView31_DataBound1(object sender, EventArgs e)
    {
        int i = 1;
        for (int rowIndex = grdView31.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        {
            GridViewRow gvRow = grdView31.Rows[rowIndex];
            GridViewRow gvPreviousRow = grdView31.Rows[rowIndex + 1];
            if (i % 4 !=0)
            {
                if (gvPreviousRow.Cells[0].RowSpan < 2)
                {
                    gvRow.Cells[0].RowSpan = 2;
                }
                else
                {
                    gvRow.Cells[0].RowSpan = gvPreviousRow.Cells[0].RowSpan + 1;
                }
                gvPreviousRow.Cells[0].Visible = false;
            }
            i++;
        }
