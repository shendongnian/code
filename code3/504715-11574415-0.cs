    var systemtime = DateTime.Now;
    var start = "Monday";
    var finish = "Wednesday";
    DayOfWeek startDay;
    if (!Enum.TryParse<DayOfWeek>(start ,out startDay))
    {
        //handle parse error 
    }
    DayOfWeek finishDay;
    if (!Enum.TryParse<DayOfWeek>(finish, out finishDay))
    {
        //handle parse error
    }
    if (systemtime.DayOfWeek < startDay || systemtime.DayOfWeek > finishDay)
    {
        MessageBox.Show("not auth.");
    }
    else
    {
        MessageBox.Show("auth.");
    }
