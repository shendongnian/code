    class Program
    {
        static void Main(string[] args)
        {
            foreach (var tz in TimeZoneInfo.GetSystemTimeZones())
            {
                var result = GetUTCOffsetsByUTCIntervals(1900, 2012, tz);
                Console.WriteLine(tz.DisplayName);
                foreach (var tuple in result)
                {
                    Console.WriteLine(tuple.Item1 + "     " + tuple.Item2 + "   " + tuple.Item3);
                }
                Console.WriteLine("------------------------------------------------------------");
            }
            Console.Read();
        }
        public static List<Tuple<TimeSpan, DateTime, DateTime>> GetUTCOffsetsByUTCIntervals(int stYear, int endYear, TimeZoneInfo tz)
        {
            var offsetsByUTCIntervals = new List<Tuple<TimeSpan, DateTime, DateTime>>();
            var adjRules = tz.GetAdjustmentRules();
            for (var year = stYear; year <= endYear && year < DateTime.MaxValue.Year && year >= DateTime.MinValue.Year; year++)
            {
                var adjRule =
                    adjRules.FirstOrDefault(
                        rule =>
                        rule.DateStart.Year == year || rule.DateEnd.Year == year ||
                        (rule.DateStart.Year < year && rule.DateEnd.Year > year));
                var yrStTime = new DateTime(year, 1, 1);
                var yrEndTime = yrStTime.AddYears(1).AddTicks(-1);
                if (adjRule != null)
                {
                    var tStDate = new DateTime(year, adjRule.DaylightTransitionStart.Month,
                                              adjRule.DaylightTransitionStart.Day);
                    var tEnddate = new DateTime(year, adjRule.DaylightTransitionEnd.Month,
                                               adjRule.DaylightTransitionEnd.Day);
                    var stTsp = adjRule.DaylightTransitionStart.TimeOfDay.TimeOfDay;
                    var endTsp = adjRule.DaylightTransitionEnd.TimeOfDay.TimeOfDay;
                    if (yrStTime.Date == tStDate && yrStTime.TimeOfDay == stTsp)
                        yrStTime = yrStTime.Add(adjRule.DaylightDelta);
                    if (yrEndTime.Date == tEnddate && yrEndTime.TimeOfDay == endTsp)
                        yrEndTime = yrEndTime.Subtract(adjRule.DaylightDelta);
                    offsetsByUTCIntervals.Add(new Tuple<TimeSpan, DateTime, DateTime>(tz.BaseUtcOffset, ConvertTimeToUtc(yrStTime, tz), ConvertTimeToUtc(tStDate.AddTicks(stTsp.Ticks - 1), tz)));
                    offsetsByUTCIntervals.Add(new Tuple<TimeSpan, DateTime, DateTime>(tz.BaseUtcOffset + adjRule.DaylightDelta, ConvertTimeToUtc(tStDate.Add(stTsp.Add(adjRule.DaylightDelta)), tz), ConvertTimeToUtc(tEnddate.AddTicks(endTsp.Ticks - 1), tz)));
                    offsetsByUTCIntervals.Add(new Tuple<TimeSpan, DateTime, DateTime>(tz.BaseUtcOffset, ConvertTimeToUtc(tEnddate.Add(endTsp.Subtract(adjRule.DaylightDelta)), tz), ConvertTimeToUtc(yrEndTime, tz)));
                }
                else
                {
                    offsetsByUTCIntervals.Add(new Tuple<TimeSpan, DateTime, DateTime>(tz.BaseUtcOffset, ConvertTimeToUtc(yrStTime, tz), ConvertTimeToUtc(yrEndTime, tz)));
                }
            }
            return offsetsByUTCIntervals;
        }
        public static DateTime ConvertTimeToUtc(DateTime date, TimeZoneInfo timeZone)
        {
            if (date == null || timeZone == null)
            {
                return date;
            }
            DateTime convertedDate = TimeZoneInfo.ConvertTimeToUtc(date, timeZone);
            return convertedDate;
        }
       /* static void GetOffsets(DateTime startTime, DateTime endTime, TimeZoneInfo tz)
        {
            var result = new HashSet<string>();
            var adjRules = tz.GetAdjustmentRules();
            result.Add(tz.BaseUtcOffset.ToString());
            foreach (var adjustmentRule in adjRules)
            {
                if ((startTime >= adjustmentRule.DateStart && startTime <= adjustmentRule.DateEnd)
                        || (endTime >= adjustmentRule.DateStart && endTime <= adjustmentRule.DateEnd)
                     || (startTime <= adjustmentRule.DateStart && endTime >= adjustmentRule.DateEnd))
                {
                    if(adjustmentRule.DaylightDelta != TimeSpan.Zero)
                    {
                        if (!result.Contains((tz.BaseUtcOffset + adjustmentRule.DaylightDelta).ToString()))
                          result.Add((tz.BaseUtcOffset + adjustmentRule.DaylightDelta).ToString());
                    }
                }
            }
            Console.Write(tz.DisplayName + "   ");
            foreach (var res in result)
            {
                Console.Write(res);
            }
        }*/
    }
