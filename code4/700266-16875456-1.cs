        public static DateTime GetNextDateOfType(this DateTime date, string ordinality, string dayType)
                {
                    var targetOrdinal = ordinality.ToOrdinal();
                    var dateTest = (targetOrdinal > -1) ? new DateTime(date.Year, date.Month, 1) : date.GetLastDayOfMonth();
                    var dateFound = false;
                    var ordinal = 1;
                    var ordinalReset = false;
                    
                    if (targetOrdinal > -1) //All cases EXCEPT "last"
                    {
                        while (!dateFound)
                        {
                            if (dateTest.Month > date.Month && !ordinalReset)
                            {
                                ordinal = 1;
                                ordinalReset = true;
                            }
        
                            //Test for type:
                            switch (dayType)
                            {
                                case "day":
                                    if (dateTest >= date)
                                    {
                                        if (dateTest.Day == targetOrdinal)
                                        {
                                            dateFound = true;
                                        }
                                    }
                                    break;
                                case "weekday":
                                    if (dateTest >= date && dateTest.IsWeekDay())
                                    {
                                        if (targetOrdinal == ordinal)
                                        {
                                            dateFound = true;
                                        }
                                    }
        
                                    if (dateTest.IsWeekDay())
                                    {
                                        ordinal++;
                                    }
        
                                    break;
                                case "weekend day":
                                    if (dateTest >= date && !dateTest.IsWeekDay())
                                    {
                                        if (targetOrdinal == ordinal)
                                        {
                                            dateFound = true;
                                        }
                                    }
                                    if (!dateTest.IsWeekDay())
                                    {
                                        ordinal++;
                                    }
        
                                    break;
                                default:
                                    if (dateTest >= date && dateTest.DayOfWeek == HelperMethods.GetDayOfWeekFromString(dayType))
                                    {
                                        if (targetOrdinal == ordinal)
                                        {
                                            dateFound = true;
                                        }
                                    }
        
                                    if (dateTest.DayOfWeek == HelperMethods.GetDayOfWeekFromString(dayType))
                                    {
                                        ordinal++;
                                    }
                                    break;
                            }
                            dateTest = (dateFound) ? dateTest : dateTest.AddDays(1);
                        }
                    }
                    else //for "last"
                    {
                        while (!dateFound)
                        {
                            if (dateTest <= date && !ordinalReset)
                            {
                                dateTest = date.GetLastDayOfMonth().AddMonths(1);
                                ordinalReset = true;
                            }
        
                            //Test for type:
                            switch (dayType)
                            {
                                case "day":
                                    dateFound = true;
                                    break;
                                case "weekday":
                                    if (dateTest.IsWeekDay())
                                    {
                                            dateFound = true;
                                    }
        
                                    break;
                                case "weekend day":
                                    if (!dateTest.IsWeekDay())
                                    {
                                        dateFound = true;
                                    }
                                    break;
                                default:
                                    if (dateTest.DayOfWeek == HelperMethods.GetDayOfWeekFromString(dayType))
                                    {
                                        dateFound = true;
                                    }
                                    break;
                            }
                            dateTest = (dateFound) ? dateTest : dateTest.AddDays(-1);
                        }
                    }
                    return dateTest;
                }
        
                public static DateTime GetLastDayOfMonth(this DateTime date)
                {
                    return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
                }
        
                public static int ToOrdinal(this string ordinal)
                {
                    var result = 0;
                    switch (ordinal.ToLower())
                    {
                        case "first":
                            result = 1;
                            break;
                        case "second":
                            result = 2;
                            break;
                        case "third":
                            result = 3;
                            break;
                        case "fourth":
                            result = 4;
                            break;
                        case "fifth":
                            result = 5;
                            break;
                        default:
                            result = -1;
                            break;
                    }
                    return result;
                }
        
                public static bool IsWeekDay(this DateTime date)
                {
                    var weekdays = new List<DayOfWeek>
                        {
                            DayOfWeek.Monday,
                            DayOfWeek.Tuesday,
                            DayOfWeek.Wednesday,
                            DayOfWeek.Thursday,
                            DayOfWeek.Friday
                        };
        
                    return weekdays.Contains(date.DayOfWeek);
                }
        
                public static List<DateTime> GetWeeks(this DateTime month, DayOfWeek startOfWeek)
                {
                    var firstOfMonth = new DateTime(month.Year, month.Month, 1);
                    var daysToAdd = ((Int32)startOfWeek - (Int32)month.DayOfWeek) % 7;
                    var firstStartOfWeek = firstOfMonth.AddDays(daysToAdd);
        
                    var current = firstStartOfWeek;
                    var weeks = new List<DateTime>();
                    while (current.Month == month.Month)
                    {
                        weeks.Add(current);
                        current = current.AddDays(7);
                    }
        
                    return weeks;
                }
        
                public static int GetWeekOfMonth(this DateTime date)
                {
                    var beginningOfMonth = new DateTime(date.Year, date.Month, 1);
        
                    while (date.Date.AddDays(1).DayOfWeek != CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
                        date = date.AddDays(1);
        
                    return (int)Math.Truncate((double)date.Subtract(beginningOfMonth).TotalDays / 7f) + 1;
                }
    
    
     public static DayOfWeek GetDayOfWeekFromString(string day)
            {
                var dow = DayOfWeek.Sunday;
                switch (day)
                {
                    case "Sunday":
                        dow = DayOfWeek.Sunday;
                        break;
                    case "Monday":
                        dow = DayOfWeek.Monday;
                        break;
                    case "Tuesday":
                        dow = DayOfWeek.Tuesday;
                        break;
                    case "Wednesday":
                        dow = DayOfWeek.Wednesday;
                        break;
                    case "Thursday":
                        dow = DayOfWeek.Thursday;
                        break;
                    case "Friday":
                        dow = DayOfWeek.Friday;
                        break;
                    case "Saturday":
                        dow = DayOfWeek.Saturday;
                        break;
                }
    
                return dow;
            }
