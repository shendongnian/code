    private void CreateColumns()
    {
        var startDate = new DateTime(2013, 05, 07);
        var endDate = new DateTime(2013, 05, 17);
        //// Ensure that startDate < endDate, no validation in this example.
        var tmp = startDate;
        while (tmp <= endDate)
        {
            GridViewColumn gc = new GridViewColumn();
            gc.Header = tmp.ToShortDateString();
            gc.Width = 100;
            this.myView.Columns.Add(gc);
            tmp = tmp.AddDays(1);
        }
    }
