    public static IEnumerable<DateTime> AllDatesInMonth(int year, int month)
            {
            int days = DateTime.DaysInMonth(year, month);
            for (int day = 1; day <= days; day++)
            {
                var dateToTest = new DateTime(year, month, day);
                if (dateToTest.DayOfWeek == DayOfWeek.Saturday || dateToTest.DayOfWeek == DayOfWeek.Sunday) continue;
                yield return dateToTest;
            }
        }
