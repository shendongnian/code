    var d2 = DateTime.Now.AddSkipWeekend(TimeSpan.FromHours(50),TimeSpan.FromHours(9),TimeSpan.FromHours(17),TimeSpan.FromHours(12));
    public static DateTime AddSkipWeekend(this DateTime date1, TimeSpan addTime, TimeSpan workStart, TimeSpan workEnd, TimeSpan middleDay)
    {
        if(middleDay < workStart || middleDay> workEnd){
            middleDay=TimeSpan.FromHours(12);
        }
        DateTime d2 = date1 + addTime;
        if(d2.TimeOfDay < workStart) {
            d2 = d2.Add(workStart - d2.TimeOfDay);
        } else if(d2.TimeOfDay > workEnd) {
            d2 = d2.Add(middleDay - d2.TimeOfDay);
        }
        if(d2.DayOfWeek == DayOfWeek.Saturday) {
            d2 = d2.AddDays(2);
        } else if(d2.DayOfWeek == DayOfWeek.Sunday) {
            d2 = d2.AddDays(1);
        }
        return d2;
    }
