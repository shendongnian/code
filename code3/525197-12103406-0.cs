    var rangeStart = new DateTime(2012, 1, 1);
    var rangeEnd = new DateTime(2012, 12, 31);
    var res = list
        .Where(item => (item.StartTime < rangeStart ? rangeStart : item.StartTime) < (item.EndTime < rangeEnd ? item.EndTime : rangeEnd) )
        .ToList();
