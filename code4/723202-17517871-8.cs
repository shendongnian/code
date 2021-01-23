    string test = "blah 1 2 3 7-Jul-13 6:15:00  4 5 6 blah";
    int formatPart = 0;
    bool dateFound = false;
    string format = "d-MMM-yy H:mm:ss";
    DateTime myDateTime = DateTime.MinValue;
    foreach (var item in test.Split(' '))
    {
        DateTime dummy;
        if (DateTime.TryParseExact(item, format.Split(' ')[formatPart], null, DateTimeStyles.NoCurrentDateDefault, out dummy))
        {
            if (myDateTime == DateTime.MinValue)
            {
                formatPart++;
                myDateTime = dummy;
                dateFound = myDateTime.Date != DateTime.MinValue.Date;
                continue;
            }
            
            // If date was found first, add time, else add date
            myDateTime = dateFound
             ? myDateTime.Add(new TimeSpan(dummy.Hour, dummy.Minute, dummy.Second))
             : dummy.Add(new TimeSpan(myDateTime.Hour, myDateTime.Minute, myDateTime.Second));
            break;
        }
    }
