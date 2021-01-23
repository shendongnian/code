    // Let's get the 3rd Friday of last month:
    // get starting date
    DateTime date = new DateTime();
    // get first day of last month
    DateTime firstOfLastMonth = date.AddMonths(-1).AddDays(-1 * (date.Day + 1));
    // subtract out the day of the week (get the previous Sunday, even if it is last month)
    DateTime justBeforeMonth = firstOfLastMonth.AddDays((int)firstOfLastMonth.DayOfWeek);
    // Add in the DayOfWeek number we are looking for
    DateTime firstFridayOfMonth = justBeforeMonth.AddDays(DayOfWeek.Friday);
    // if we are still in last month, add a week to get into this month
    if (firstFridayOfMonth.Month != date.AddMonth(-1).Month) { firstFridayOfMonth.AddDays(7); }
    // add in 2 weeks to get the third week of the month
    DateTime thirdFridayOfMonth = firstFridayOfMonth.AddDays(14);
