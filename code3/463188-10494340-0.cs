    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        AddToDates(Calendar1.SelectedDate);
    }
    private void AddToDates(DateTime newDate)
    {
        DateTime selecteddate;
        ArrayList datelist;
        if (ViewState["SelectedDates"] != null)
        {
            datelist = (ArrayList)ViewState["SelectedDates"];
            for (int x = 0; x < datelist.Count; x++)
            {
                selecteddate = (DateTime)datelist[x];
                Calendar1.SelectedDates.Add(selecteddate);
            }
        }
        else
        {
            datelist = new ArrayList();
        }
        if (datelist.Contains(newDate))
        {
            Calendar1.SelectedDates.Remove(newDate);
            datelist.Remove(newDate);
        }
        else
        {
            Calendar1.SelectedDates.Add(newDate);
            datelist.Add(newDate);
        }
        ViewState["SelectedDates"] = datelist;
    }
