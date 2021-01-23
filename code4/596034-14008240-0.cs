    private string previous { get; set; }
    private string current { get; set; }
    private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
    {
        previous = current;
        current = monthCalendar1.SelectionRange.Start.ToShortDateString();
    }
