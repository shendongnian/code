    protected void Page_Load(object sender, EventArgs e)
    {
        Calendar1.SelectedDates.Add(new DateTime(2012, 5, 1));
        Calendar1.SelectedDates.Add(new DateTime(2012, 5, 5));
        Calendar1.SelectedDates.Add(new DateTime(2012, 5, 9));
    }
