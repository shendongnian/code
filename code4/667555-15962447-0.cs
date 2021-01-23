    private void CreateColumns()
    {
        var startDate = new DateTime(2013, 05, 07);
        var endDate = new DateTime(2013, 05, 17);
        //// Ensure that startDate < endDate, no validation in this example.
        var tmp = startDate;
        while (tmp <= endDate)
        {
            this.listView1.Columns.Add(tmp.ToShortDateString());
            tmp = tmp.AddDays(1);
        }
    }
