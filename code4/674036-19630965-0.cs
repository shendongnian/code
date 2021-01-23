                DateTime start = DateTime.Now;
                DateTime end = start + TimeSpan.FromMinutes(30);
                var curTZone = TimeZone.CurrentTimeZone;
                var dateStart = new DateTimeOffset(start, curTimeZone.GetUtcOffset(start));
                var dateEnd = new DateTimeOffset(end, curTimeZone.GetUtcOffset(end));
                var startTimeString = dateStart.ToString("o");
                var endTimeString = dateEnd.ToString("o");             
                
                evnt.Start = new EventDateTime()
                {                    
                    DateTime = startTimeString 
                };
                evnt.End = new EventDateTime()
                {
                    DateTime = endTimeString
                };
