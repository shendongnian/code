            public static Boolean TryParseExact(String s, String format, IFormatProvider provider,
                                DateTimeStyles style, out DateTime result, DateTime defaultTime)
        {
            // Determine whether the format requires that the time-of-day is in the string to be converted.
            // We do this by creating two strings from the format, which have the same date but different
            // time of day.  If the two strings are equal, then clearly the format contains no time-of-day
            // information.
            Boolean willApplyDefaultTime = false;
            DateTime testDate1 = new DateTime(2000, 1, 1, 2, 15, 15);
            DateTime testDate2 = new DateTime(2000, 1, 1, 17, 47, 29);
            String testString1 = testDate1.ToString(format);
            String testString2 = testDate2.ToString(format);
            if (testString1 == testString2)
                willApplyDefaultTime = true;
            // Let method DateTime.TryParseExact do all the hard work
            Boolean success = DateTime.TryParseExact(s, format, provider, style, out result);
            if (success && willApplyDefaultTime)
            {
                DateTime rawResult = result;
                // If the format contains no time-of-day information, then apply the default from
                // this method's parameter value.
                result = new DateTime(rawResult.Year, rawResult.Month, rawResult.Day,
                                 defaultTime.Hour, defaultTime.Minute, defaultTime.Second);
            }
            return success;
        }
