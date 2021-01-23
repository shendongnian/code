        /// <summary>
        /// Returns a string approximation of the time since the specified time.
        /// </summary>
        /// <param name="adDate">The ad date.</param>
        /// <returns></returns>
        public static string TimeSincePosted(string adDate)
        {
            return TimeSincePosted(DateTime.ParseExact(adDate, "\D\a\t\e: yyyy-MM-dd, hh:mmtt K", CultureInfo.CurrentUICulture));
        }
        /// <summary>
        /// Returns a string approximation of the time since the specified time.
        /// </summary>
        /// <param name="adDate">The ad date.</param>
        /// <returns></returns>
        public static string TimeSincePosted(DateTime adDate)
        {
            TimeSpan delta = DateTime.Now - adDate;
            if( delta.TotalDays > 1 )
            {
                return string.Format("{0} days ago", delta.TotalDays);
            }
            else if( delta.TotalDays == 1)
            {
                return "1 day ago";
            }
            else if( delta.TotalHours > 1)
            {
                return string.Format("{0} hrs", delta.TotalHours);
            }
            else if( delta.TotalHours == 1)
            {
                return "1 hr";
            }
            else if( delta.TotalMinutes > 1)
            {
                return string.Format("{0} mins", delta.TotalMinutes);
            }
            else if( delta.TotalMinutes == 1)
            {
                return "1 min";
            }
            else
            {
                return "0 mins";
            }
        }
