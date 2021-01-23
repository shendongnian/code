     public DateTimeOffset universalParser(string inputDate, int type)
        {
            switch (type)
            {
                case 1:
                    return DateTimeOffset.Parse(inputDate,
                                                CultureInfo.InvariantCulture);
                case 2:
                    return DateTimeOffset.ParseExact(inputDate,
                                      "ddd MMM dd HH:mm:ss \"UTC\"zzz yyyy",
                                       CultureInfo.InvariantCulture);                         
            }
            //if there is another type
            return DateTimeOffset.Parse(inputDate);
        }
