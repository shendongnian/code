    var d2 = DateTime.Now.AddSkipWeekend(TimeSpan.FromHours(40));
    
    static class DateExtensions { 
        public static DateTime AddSkipWeekend(this DateTime date1, TimeSpan ts){
            DateTime d2 = date1 + ts;
            if(d2.DayOfWeek == DayOfWeek.Saturday) {
                d2 = d2.AddDays(2);
            } else if(d2.DayOfWeek == DayOfWeek.Sunday) {
                d2 = d2.AddDays(1);
            }
            return d2;
        }
    }
