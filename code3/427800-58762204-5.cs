    static DateTime GetNextRun(int hour, int min, bool isDaily, bool isWeekly, bool isMonthly, bool isLastDayOfMonth, int collectionDay)
            {
                var today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, min, 0, 0);
                var tomorrow = today.AddDays(1);
    
                if (isDaily)
                {
                    return tomorrow;
                }
                else if (isWeekly)
                {
                    if (collectionDay < 2)
                    {
                        throw new Exception("The collection Day is invalid.");
                    }
    
                    if (collectionDay > 255)
                    {
                        throw new Exception("The collection Day is invalid.");
                    }
    
                    for (int i = 1; i < 8; i++)
                    {
                        var dayOfWeek = (int)today.AddDays(i).DayOfWeek;
                        var power = (int)(Math.Pow(2, dayOfWeek + 1));
                        if ((power & collectionDay) > 0)
                        {
                            return today.AddDays(i);
                        }
                    }
                }
                else if (isMonthly)
                {
                    var nextDate = tomorrow;
    
                    if (collectionDay < 2 && isLastDayOfMonth)
                    {
                        return new DateTime(tomorrow.Year, tomorrow.Month, GetDaysInMonth(tomorrow), hour, min, 0, 0);
                    }
    
                    if (collectionDay < 2)
                    {
                        throw new Exception("The collection Day is invalid.");
                    }
    
                    while (true)
                    {
                        var power = (int)(Math.Pow(2, nextDate.Day));
                        if ((power & collectionDay) > 0)
                        {
                            if (isLastDayOfMonth && nextDate.Month != tomorrow.Month)
                            {
                                return new DateTime(tomorrow.Year, tomorrow.Month, GetDaysInMonth(tomorrow), hour, min, 0, 0);
                            }
    
                            return nextDate;
                        }
    
                        nextDate = nextDate.AddDays(1);
                    }
                }
    
                return DateTime.MaxValue;
            }
    
            static int GetDaysInMonth(DateTime d)
            {
                for (int i = 28; i < 33; i++)
                {
                    try
                    {
                        new DateTime(d.Year, d.Month, i, 1, 1, 0, 0);
                    }
                    catch (Exception)
                    {
                        return (i - 1);
                    }
                }
    
                return 31;
            }
