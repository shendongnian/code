    List<string> ListTimes = new List<string>() { "09.00 AM", "12.00 PM", "03.00 PM" };
    string testTimeString = "01.00 PM";
    DateTime testTime = DateTime.ParseExact(testTimeString, "hh.mm tt", CultureInfo.InvariantCulture);
    
    return ListTimes
        .Select(x => new
        {
            Time = x,
            Difference = (DateTime.ParseExact(x, "hh.mm tt", CultureInfo.InvariantCulture) - testTime).Duration()
        })
        .OrderBy(x => x.Difference)
        .First().Time;
