    int ToOrdinal(DateTime d, DateTime baseLine) {
       if (d.Day <= 7
           && d.DayInWeek == baseLine.DayInWeek) {
          // Since there is only one "First Friday" a month, and there are
          // 12 months in year we can easily compose the ordinal.
          return d.Year * 12 + d.Month;
       } else {
          // Was not correct "kind" of day -
          // Maybe baseLine is Tuesday, by d represents Wednesday.
          return -1;
       }
    }
    var dates = ..;
    var baseLine = dates.FirstOrDefault();
    var ordinals = dates.Select(d => ToOrdinal(d, baseLine));
