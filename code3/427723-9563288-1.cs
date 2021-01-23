    for (int i = 1; i <= 12; ++i)
    {
        DateTime firstDate = new DateTime(2012, i, 1, 0, 0, 0);
        int daysInMonth = DateTime.DaysInMonth(2012, i);
        DateTime endDate = new DateTime(2012, i, daysInMonth-1, 23, 59, 59);
        DateTime TransactionDate = new DateTime(2012, i, daysInMonth, 0, 0, 0);
        Console.WriteLine(firstDate.ToString() + 
                    "," + endDate.ToString() + 
                    "," + TransactionDate.ToString());
     }
