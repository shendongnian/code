    int n = 0;
    for (int i = 0; i < billTotals.Count; i += n)
    {
        dateValue = dateList[i];
        oneDayTotal = 0;
        n = 0;  // This counts the number of equal dates.
        while (i + n < dateList.Length && dateValue == dateList[i + n])
        {
            oneDayTotal += billTotals[i + n];
            n++;
        }
        dailyTotals.Add(oneDayTotal);
    }
    return dailyTotals;
