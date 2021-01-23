    public DateTime NextDate {
        get {
            DateTime today = DateTime.Today;
            DateTime now = DateTime.Now;
            int daysUntilWeekday = ((int)Day - (int)today.DayOfWeek + 7) % 7;
            DateTime nextWeekDay = today.AddDays(daysUntilWeekday);
            var nextTime = nextWeekDay.AddSeconds(Second).AddMinutes(Minute).AddHours(Hour);
            if (nextTime < DateTime.Now) {
                return nextTime.AddDays(7);
            }
            else {
                return nextTime;
            }
        }
    }
