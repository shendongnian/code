    string localTimeZoneId = sysParamsHelper.ReadString(LOCAL_TIME_ZONE_ID_KEY, LOCAL_TIME_ZONE_DEFAULT_ID);
        ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();
        foreach (TimeZoneInfo timeZoneInfo in timeZones)
        {                
           if(timeZoneInfo.Id.Equals(localTimeZoneId))
           {
               m_localTimeZone = timeZoneInfo;
               break;
           }
        }
        if (m_localTimeZone == null)
        {
            m_logger.Error(LogTopicEnum.AMR, "Could not find time zone with id: " + localTimeZoneId + " . will use default time zone (UTC).");
            m_localTimeZone = TimeZoneInfo.Utc;
        }          
