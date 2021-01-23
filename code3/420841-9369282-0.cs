    private int GetWorkingDaysLeftInMonth()
        {
            // get the daysInMonth
            int daysInMonth = GetDaysInMonth();
            // locals
            int businessDaysInMonth = 0;
            int day = DateTime.Now.Day;
            bool isWeekDay = false;
            int currentDay = (int) DateTime.Now.DayOfWeek;
            DayOfWeek dayOfWeek = (DayOfWeek)currentDay;
            
            // iterate the days in month
            for (int x = day; x < daysInMonth; x++)
            {
                // increment the current day
                currentDay++;
                // if the day is greater than 7
                if (currentDay > 7)
                {
                    // reset the currentDay
                    currentDay = 1;
                }
                // get the dayOfWeek
                dayOfWeek = (DayOfWeek) currentDay;
                switch(dayOfWeek)
                {
                    case DayOfWeek.Monday:
                    case DayOfWeek.Tuesday:
                    case DayOfWeek.Wednesday:
                    case DayOfWeek.Thursday:
                    case DayOfWeek.Friday:
                        // is a week day
                        isWeekDay = true;
                        // required
                        break;
                    default:
                        // is a NOT week day
                        isWeekDay = true;
                        // required
                        break;
                }
                if (isWeekDay)
                {
                    // increment the value
                    businessDaysInMonth++;  
                }
            }
            // return value
            return businessDaysInMonth;
        }
        private int GetDaysInMonth()
        {
            // initial value
            int daysInMonth = 0;
            switch(DateTime.Now.Month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    daysInMonth = 31;
                    // required;
                    break;
                case 2:
                    daysInMonth = 28;
                    // to do (leap year)
                    bool isLeapYear = IsLeapYear();
                    // if isLeapYear
                    if (isLeapYear)
                    {
                        // set to 29
                        daysInMonth = 29;
                    }
                    // required
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    daysInMonth = 30;
                    // required;
                    break;
            }
            // return value
            return daysInMonth;
        }
        private bool IsLeapYear()
        { 
            // initial value
            bool isLeapYear = false;
            int year = DateTime.Now.Year;
            //determine the year
            switch(year)
            {
                case 2012:
                case 2016:
                case 2020:
                // to do: Go as far out as you need to
                    // set to true
                    isLeapYear = true;
                    // required
                    break;
            }
            // return value
            return isLeapYear;
        }
