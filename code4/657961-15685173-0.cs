    All = All.OrderBy(s => {
      int value;
      if (!Int32.TryParse(s.Split('|')[1], out value)) {
        value = Int32.MaxValue;
      }
      return value;
    }).ToList();
