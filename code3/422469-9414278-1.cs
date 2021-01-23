        var d1 = DateTime.Now;
        var ts = TimeSpan.FromHours(40);
        var d2 = d1 + ts;
        if(d2.DayOfWeek == DayOfWeek.Saturday) {
            d2 = d2.AddDays(2);
        }else if(d2.DayOfWeek == DayOfWeek.Sunday){
            d2 = d2.AddDays(1);
        }
