    protected void dltest_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        var dataItem = e.Item.DataItem as DataRowView;
        int wholeDay = 8;
        int halfDay = 4;
        if (dataItem != null)
        {
            if ((int)dataItem["hoursCol"] == wholeDay)
                e.Item.FindControl("FullDayImage").Visible = true;
            else if ((int)dataItem["hoursCol"] == halfDay)
                e.Item.FindControl("HalfDayImage").Visible = true;
            else
            {
                var hoursTextBox = e.Item.FindControl("Hours") as TextBox;
                hoursTextBox.Text = dataItem["hoursCol"].ToString();
                hoursTextBox.Visible = true;
            }
        }
    }
