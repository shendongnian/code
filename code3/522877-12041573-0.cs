    bool condition1 = !DateTime.TryParseExact(txtComStartDate.Text, "dd/MM/yy", provider, DateTimeStyles.AssumeLocal, out startDate);
    bool condition2 = DateTime.Parse(itemDate, provider, DateTimeStyles.AssumeLocal) >= startDate);
    bool condition3 = !DateTime.TryParseExact(txtComEndDate.Text, "dd/MM/yy", provider, DateTimeStyles.AssumeLocal, out endDate);
    bool condition4 = DateTime.Parse(itemDate, provider, DateTimeStyles.AssumeLocal) <= endDate);
    
    if ((condition1
          || condition2 &&
          (condition3
          || condition4)
