    int bitmask = DayOfWeek.Sun | DayOfWeek.Mon |DayOfWeek.Fri;
    var item = Context.tbl.First();
    item.DayOfWeekBitMask = bitmask;
    Context.SaveChanges();
    
