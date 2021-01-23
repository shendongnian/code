    public static class DateTimeExtension
        {
            public static string GetLocaleDateTimeFormating(this DateTime T )  
            {
                DateTimeFormatInfo sysUIFormat = CultureInfo.CurrentUICulture.DateTimeFormat;
                string customFormat = sysUIFormat.ShortDatePattern.Replace("d", "dd").Replace("M", "MM");
                customFormat += " " + sysUIFormat.ShortTimePattern.Replace("h", "hh").Replace("H", "HH");
                string newDate = T.ToString(customFormat);
                return newDate;
            }
        }
