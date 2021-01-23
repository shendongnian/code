    var orderedShifts = ShiftSets.OrderBy(x=>x.StartDate).ToList();
    
    var compactShifts = new List<Shift>();
    compactShifts.Add(orderedShifs[0]);
    
    foreach (var item in orderedShift)
    {
        if (item.Start <= compactShifts[compactShifts.Count-1].End 
            && item.End > compactShifts[compactShifts.Count-1].End)
        {
            compactShifts[compactShifts.Count-1].End = item.End;
        } 
        else if (item.Start > compactShifts[compactShifts.Count-1].End)
          compactShifts.Add(item);
    }  
    
    //run similar procedure for schedule exceptions to create compact schedules.
    
    var validShifts = new List<Shift>();
    
    foreach (var item in compactShifts)
    {
       var shiftCheatingPart = compactExceptions
                              .FirstOrDefault(x=>x.Start < item.Start 
                                             && x.End > item.End)
       if (shiftCheatingPart != null)
       {
           if (item.End <= shiftCheatingPart.End)
             continue;
    
           validShifts.Add(new Shift{Start = shiftCheatingPart.End,End = item.End);
       }
    }
    
    var totalTimes = validShifts.Sum(x=>x.End.Sunbtract(x.Start).TotalHours);
