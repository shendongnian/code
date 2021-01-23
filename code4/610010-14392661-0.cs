    string ClientTime = ConvertDatebyUserTimezone(UserTimeZone, dateToConvert).ToString();
    
    public DateTime ConvertDatebyUserTimezone(string UserTimezone, DateTime SrcDate)
            {
                DateTime Returndate = SrcDate;                
                TimeZoneInfo Serverzone = null;
                System.Collections.ObjectModel.ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();
                foreach (TimeZoneInfo timeZoneInfo in timeZones)
                {
                   if (timeZoneInfo.ToString().Contains(ToConvertTimezone))
                   {
                      Serverzone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneInfo.Id);
                      break;
                   }
                }
                if (UserTimezone != "")
                {
                    foreach (TimeZoneInfo timeZoneInfo in timeZones)
                    {
                        if (timeZoneInfo.ToString().Contains(UserTimezone))
                        {
                            TimeZoneInfo timez = TimeZoneInfo.FindSystemTimeZoneById(timeZoneInfo.Id);
                            Returndate = TimeZoneInfo.ConvertTime(SrcDate, ToConvertTimezone, timez);
                            break;
                        }
                    }
                }
                return Returndate;
            }
