         protected void calDate_SelectionChanged(object sender, EventArgs e)
    {
        txtDate.Text = calDate.SelectedDate.ToString("d");
    }
     protected void calDate_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
      ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script language=JavaScript>popupCalendar();</script>");
    }
