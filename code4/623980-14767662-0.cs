            //build a date for the month and year selected by the user
            DateTime newDate = new DateTime(yearSelected, monthSelected, 1);
            //iterate through the days in that month
            for (int i = newDate.Day; i < DateTime.DaysInMonth(newDate.Year, newDate.Month); i++ )
            {
                //add to your list
            }
