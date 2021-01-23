            public static int DateDiff(string Interval, DateTime Date1, DateTime Date2)
        {
            int difVale = 0;
            DateTime startDate, endDate;
            if (Date1 > Date2)
            {
                endDate = Date1; 
                startDate = Date2;
            }
            else
            {
                startDate = Date1; 
                endDate = Date2;
            }
            switch (Interval)
            {
                case "D":
                case "d":
                    for (int nYear = startDate.Year; nYear < endDate.Year; nYear++)
                    {
                        difVale += new DateTime(nYear, 12, 31).DayOfYear;
                    }
                    difVale += endDate.DayOfYear - startDate.DayOfYear;
                    break;
                case "M":
                case "m":
                    difVale = endDate.Year - startDate.Year;
                    difVale = difVale * 12;
                    difVale += endDate.Month - startDate.Month;
                    break;
                case "Y":
                case "y":
                    difVale = endDate.Year - startDate.Year;
                    break;
            }
            if (Date1 > Date2)
            {
                difVale = -difVale;
            }
            return difVale;
        }
