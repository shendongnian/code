        public static DateTime RoundDown(DateTime dateTime)
        {
            long remainingTicks = dateTime.Ticks % PeriodLength.Ticks;
            return dateTime - new TimeSpan(remainingTicks);
        }
