        DateTime sdate = CalcHelper.AbsoluteStart(model.StartDate);
        DateTime edate = CalcHelper.AbsoluteEnd(model.EndDate);
        public static DateTime AbsoluteStart(this DateTime dateTime)
        {
            return dateTime.Date.ToUniversalTime();
        }
        public static DateTime AbsoluteEnd(this DateTime dateTime)
        {
            return AbsoluteStart(dateTime).AddDays(1).AddTicks(-1).ToUniversalTime();
        }
