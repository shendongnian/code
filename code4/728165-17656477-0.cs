    DataTime? a;
    DateTime? b; 
    TimeSpan? duration;
    
    // Assign values to a and b...
    
    if(a.HasValue && b.HasValue)
    {
      duration = b.Value - a.Value;
    }
    
    var days = duration.GetValueOrDefault().TotalDays;
    var hour = duration.GetValueOrDefault().TotalHours;
