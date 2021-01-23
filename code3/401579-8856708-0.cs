    public int DateTime startdate {....}
    
    public int Hour {
     get{ return  startdate.Hour; }
    set { MyDateTime = DateTime(startdate.Year, startdate.Month, startdate.Day, value, startdate.Minute, 0);
    }
    }
