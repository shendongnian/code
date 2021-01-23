    protected void testimggv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var dataItem = e.Row.DataItem as DataRowView;
        int wholeDay = 8;
        int halfDay = 4;
        if (dataItem != null)
        {
            if ((int)dataItem["hoursCol"] == wholeDay)
                e.Row.FindControl("FullDayImage").Visible = true;
            else if ((int)dataItem["hoursCol"] == halfDay)
                e.Row.FindControl("HalfDayImage").Visible = true;
            else
            {
                var hoursTextBox = e.Row.FindControl("Hours") as TextBox;
                hoursTextBox.Text = dataItem["hoursCol"].ToString();
                hoursTextBox.Visible = true;
            }
        }
    }
