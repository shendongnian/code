    string test = "blah 1 2 3 7-Jul-13 6:15:00 4 5 6 blah";
    
    int part = 0;
    string format = "d-MMM-yy H:mm:ss";
    DateTime myDateTime = DateTime.MinValue;
    foreach (var item in test.Split(' '))
    {
        DateTime dummy;
        if (DateTime.TryParseExact(item, format.Split(' ')[part], null, DateTimeStyles.None, out dummy))
        {
            if (myDateTime == DateTime.MinValue)
            {
                part++;
                myDateTime = dummy;
                continue;
            }
            myDateTime = myDateTime.Add(new TimeSpan(dummy.Hour, dummy.Minute, dummy.Second));
        }
    }
