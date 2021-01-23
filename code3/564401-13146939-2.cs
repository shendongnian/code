    var query = promoCodes.AsEnumerable();
    
    if (!String.IsNullOrEmpty(fieldTitle) && !String.IsNullOrEmpty(fieldValue))
        query = query.Where(row => row[fieldTitle].Equals(filterValue));
    
    var result = query.Select(row => new PromoCodeInfoContainer { ... });
