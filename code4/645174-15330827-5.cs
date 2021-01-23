    int ToOrdinal(DateTime d, DateTime baseline) {
       if (d.Day <= 7
           && d.DayInWeek == baseline.DayInWeek) {
          // Since there is only one "First Friday" a month, and there are
          // 12 months in year we can easily compose the ordinal.
          // (As per default.kramer's comment, months normalized to [0,11].)
          return d.Year * 12 + (d.Month - 1);
       } else {
          // Was not correct "kind" of day -
          // Maybe baseline is Tuesday, but d represents Wednesday or
          // maybe d wasn't in the first week ..
          return -1;
       }
    }
    var dates = ..;
    var baseline = dates.FirstOrDefault();
    var ordinals = dates.Select(d => ToOrdinal(d, baseline));
