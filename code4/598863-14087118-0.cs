    List<string> timespanStrings = new List<string>() { 
        "312 Days 21 Hours 16 Minutes 5 Seconds", "21 Hours 16 Minutes 5 Seconds",
        "16 Minutes 5 Seconds", "5 Seconds"
    };
    List<TimeSpan> timespans = new List<TimeSpan>();
    foreach (string tsString in timespanStrings)
    {
        List<Tuple<int, string>> pairs = new List<Tuple<int, string>>();
        var tokens = tsString.Split();
        if (tokens.Length % 2 == 0)
        {
            int duration;
            for (int i = 0; i < tokens.Length; i += 2)
            {
                string dur = tokens[i];
                string unit = tokens[i + 1];
                if (int.TryParse(dur, out duration))
                {
                    pairs.Add(Tuple.Create(duration, unit));
                }
                else // invalid string
                    break;
            }
        }
        // create the TimeSpan from the pair
        switch (pairs.Count)
        {
            case 4:  // days
                {
                    var dayPair = pairs.First(p => p.Item2.Equals("Days", StringComparison.OrdinalIgnoreCase));
                    TimeSpan ts = TimeSpan.FromDays(dayPair.Item1);
                    var hourPair = pairs.First(p => p.Item2.Equals("Hours", StringComparison.OrdinalIgnoreCase));
                    TimeSpan tsHour = TimeSpan.FromHours(hourPair.Item1);
                    var minPair = pairs.First(p => p.Item2.Equals("Minutes", StringComparison.OrdinalIgnoreCase));
                    TimeSpan tsMin = TimeSpan.FromMinutes(minPair.Item1);
                    var secPair = pairs.First(p => p.Item2.Equals("Seconds", StringComparison.OrdinalIgnoreCase));
                    TimeSpan tsSec = TimeSpan.FromSeconds(secPair.Item1);
                    ts = ts + tsHour + tsMin + tsSec;
                    timespans.Add(ts);
                    break;
                }
            case 3:  // hours
                {
                    var hourPair = pairs.First(p => p.Item2.Equals("Hours", StringComparison.OrdinalIgnoreCase));
                    TimeSpan ts = TimeSpan.FromHours(hourPair.Item1);
                    var minPair = pairs.First(p => p.Item2.Equals("Minutes", StringComparison.OrdinalIgnoreCase));
                    TimeSpan tsMin = TimeSpan.FromMinutes(minPair.Item1);
                    var secPair = pairs.First(p => p.Item2.Equals("Seconds", StringComparison.OrdinalIgnoreCase));
                    TimeSpan tsSec = TimeSpan.FromSeconds(secPair.Item1);
                    ts = ts + tsMin + tsSec;
                    timespans.Add(ts);
                    break;
                }
            case 2:  // minutes
                {
                    var minPair = pairs.First(p => p.Item2.Equals("Minutes", StringComparison.OrdinalIgnoreCase));
                    TimeSpan ts = TimeSpan.FromMinutes(minPair.Item1);
                    var secPair = pairs.First(p => p.Item2.Equals("Seconds", StringComparison.OrdinalIgnoreCase));
                    TimeSpan tsSec = TimeSpan.FromSeconds(secPair.Item1);
                    ts = ts + tsSec;
                    timespans.Add(ts);
                    break;
                }
            case 1:  // seconds
                timespans.Add(TimeSpan.FromSeconds(pairs[0].Item1));
                break;
            default: 
                break;
        }
    }
