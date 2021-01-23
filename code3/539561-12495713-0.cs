    private string GetAnswer()
    {
        DateTime birthday = calBirthDate.SelectedDate;
        TimeSpan difference = DateTime.Now.Date - birthday;
        int leapYears = CountLeapYears(birthday);
        int days = (int)difference.TotalDays - leapYears;
        int hours = (int)difference.TotalHours - leapYears * 24;
        int years = days / 365;
        String answer = String.Format("Age: {0} years", years);
        answer += Environment.NewLine;
        answer += String.Format("Days: {0}*365+{1} = {2}", years, days - years * 365, days);
        answer += Environment.NewLine;
        answer += String.Format("Days Hours: {0}*24 = {1}", hours / 24, hours);
        return answer;
    }
    private int CountLeapYears(DateTime startDate)
    {
        int count = 0;
        for (int year = startDate.Year; year <= DateTime.Now.Year; year++)
        {
            if (DateTime.IsLeapYear(year))
            {
                DateTime february29 = new DateTime(year, 2, 29);
                if (february29 >= startDate && february29 <= DateTime.Now.Date)
                {
                    count++;
                }
            }
        }
        return count;
    }
