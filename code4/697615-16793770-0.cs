    protected void grdContents_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowIndex == 0)
                e.Row.BackColor = Color.Gray;
            else
            {
                var thisKey = grdContents.DataKeys[e.Row.RowIndex].Value;
                var prevKey = grdContents.DataKeys[e.Row.RowIndex - 1].Value;
                var prevRow = grdContents.Rows[e.Row.RowIndex - 1];
                if (thisKey.Equals(prevKey))
                    e.Row.BackColor = prevRow.BackColor;
                else
                    e.Row.BackColor = prevRow.BackColor == Color.Gray ? Color.White : Color.Gray;
            }
        }
    }
