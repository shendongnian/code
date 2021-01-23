    // parse your 'openTime' and 'closeTime'
    List<DateTime> list = new List<DateTime>();
    
    DateTime step = openTime.AddMinutes(45);
    
    while (step<closeTime) {
       list.Add(step);
       step = step.AddMinutes(15);
    }
