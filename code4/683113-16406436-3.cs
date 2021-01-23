        public static string ToStringWithArticle(this DateTime dateTime, string format, IFormatProvider provider)
        {
            var dateTimeString = dateTime.ToString(format, provider);
            if (provider == new CultureInfo("nl-BE"))
            {
                dateTimeString = "le " + dateTimeString;
            }
            return dateTimeString;
        }
