        //Example initial time to 1 houre == 100%
        TimeSpan InitialTime = new TimeSpan(1, 0, 0);
        private double getPercentOnTime(TimeSpan currentTime,TimeSpan timeToRemove)
        {
            //Convert all to minutes
            double currentTime_minute = currentTime.TotalMinutes;
            double timeToRemove_minute = timeToRemove.TotalMinutes;
            double InitialTime_minute = InitialTime.TotalMinutes;
            //Calcul the additional time to remove from InitialTime
            double totaltimeToRemove = currentTime_minute + timeToRemove_minute;
            //calcul the new percent
            double percent = (InitialTime_minute / 100.0) * totaltimeToRemove;
            return percent;
        }
