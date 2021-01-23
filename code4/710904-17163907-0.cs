        string val = rule.Data;
        if (!string.IsNullOrEmpty(val))
        {
            switch (rule.Field)
            {
                  case "Date":
                  {
                    rows = rows.Where(o => o.Date.ToString("dd/MM/yyyy") == 
                                              DateTime.ParseExact(val,
                                              "dd/MM/yyyy",
                                              CultureInfo.InvariantCulture));
                    break;
                  }
            }
        }
