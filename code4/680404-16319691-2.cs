    return Orders
      .Where(o => 
          o.OrderDateTime > fromDate && o.OrderDateTime < toDate
          && (
              o.OrderDateTime.Hours * 60 + o.OrderDateTime.Minutes
               > 
              fromTime.Hours * 60 + fromTime.Minutes
             )
          && (
             o.OrderDateTime.Hours * 60 + o.OrderDateTime.Minutes
              <
              toTime.Hours * 60 + toTime.Minutes
             )
       );
