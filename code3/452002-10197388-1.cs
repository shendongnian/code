    DateTime baseDate = new DateTime(2012, 04, 13);
    DateTime today = DateTime.Today;
    int days = (int)(today - baseDate).TotalDays;
    int rem = days % 14;
    DateTime mostRecentAlternateFriday = today.AddDays(-rem);
