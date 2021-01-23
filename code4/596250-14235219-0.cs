     protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        bindgrid();
        var row = ((GridView)sender).Rows[e.NewEditIndex].Cells;
        for (int i = 0; i < row.Count; i++)
        {
            DateTime dtDate;
            var res = DateTime.TryParse(row[i].Text, out dtDate);
            if (res)
            {
                Calendar cal = new Calendar();
                cal.SelectedDate = dtDate;
                cal.VisibleDate = dtDate;
                cal.DataBind();
                //DatePickerControl.DatePicker text = new DatePickerControl.DatePicker();
                //text.CalendarDate = dtDate;
                row[i].Controls.Clear();
                row[i].Controls.Add(cal);
            }
        }
       
    }
