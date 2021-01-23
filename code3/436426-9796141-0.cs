    if (rdr.IsDBNull("timeIn")))
    {
        Console.Write("yeup it's null");
        queryResult2.EventTime = DateTime.MinValue;
    }
    else
    {
        queryResult.EventTime = rdr.GetDateTime("timeIn");
    }
