     public static string FormattedTime(this TimeSpan TimeIn24Hours)
        {
            String TimeIn12Hours = string.Empty;
            if (TimeIn24Hours != null)
            {
                TimeIn12Hours = DateTime.MinValue.AddHours(TimeIn24Hours.Hours).AddMinutes(TimeIn24Hours.Minutes).ToString("hh:mm");
            }
            return TimeIn12Hours;
        }
