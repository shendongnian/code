    private Object lastValue = null;
    private Color lastColor = Color.Yellow;
    protected void gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView row = (DataRowView)e.Row.DataItem;
            Object thisValue = row["Column1"];
            if(thisValue == lastValue)
                e.Row.BackColor = lastColor;
            else
                e.Row.BackColor = lastColor == Color.Yellow ? Color.Pink : Color.Yellow;
            lastValue = thisValue;
            lastColor = e.Row.BackColor;
        }
    }
