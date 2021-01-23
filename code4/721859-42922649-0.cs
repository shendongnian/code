    private DateTime GetDate(string date)
            {
                DateTime dateTime = new DateTime();
                string[] formats = CultureInfo.CurrentUICulture.DateTimeFormat.GetAllDateTimePatterns();
                try
                {
                    dateTime = DateTime.ParseExact(date, formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
                }
                catch
                {
                    throw ...;
                }
                return dateTime;
            }
