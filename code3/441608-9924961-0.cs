    protected void Grid_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var row = ((DataRowView)e.Row.DataItem).Row;
            Double sWorkTime = row.Field<Double>("sWorkTime");
            TimeSpan ts = TimeSpan.FromHours(sWorkTime);
            String formattedTimespan = String.Format(@"{0:hh\:mm\:ss}", ts);
            e.Row.Cells[1].Text = formattedTimespan;
        }
    }
