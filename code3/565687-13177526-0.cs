    void GridView31_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow )
        {
            if (e.Row.RowIndex % 4 == 0)
            {
                e.Row.Cells[0].Attributes.Add("rowspan", "4");
            }
            else
            {
                e.Row.Cells[0].Visible = false;
            }
        }
    }
