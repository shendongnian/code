    var query = row.Offenses.Where(x => x.Desc == co.Desc 
                                        && x.Action == co.Action 
                                        && x.AppealYN == co.AppealYN)
    if (co.OffenseDate.HasValue)
    {
      query = query.Where(x.OffDate == co.OffenseDate);
    }
    
    var Lookup = query.ToList();
