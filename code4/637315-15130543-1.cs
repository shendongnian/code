        public DateTime ToLocalTime(DateTime utcTime)
        {
            //Assumes that even if utcTime kind is no properly deifned it is indeed UTC time
            DateTime serverTime= new DateTime(utcTime.Ticks, DateTimeKind.Utc);
            return TimeZoneInfo.ConvertTimeFromUtc(serverTime, m_localTimeZone);            
        }
