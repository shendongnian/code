    string test = "blah 1 2 3 7-Jul-13 6:15:00 4 5 6 blah";
    DateTime myDateTime = DateTime.MinValue;
    foreach (var item in test.Split(' '))
    {
        DateTime dummy;
        if (DateTime.TryParse(item, out dummy))
        {
            if (myDateTime == DateTime.MinValue)
            {
                myDateTime = dummy;
                continue;
            }
            myDateTime = myDateTime.Add(new TimeSpan(dummy.Hour, dummy.Minute, dummy.Second));
        }
    }
