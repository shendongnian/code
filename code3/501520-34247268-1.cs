    // The Class To Check If You're Off Work
    class DayOffChecker
    {
        public bool CheckDays(List<string> DaysOff)
        {
            string CurrentDay = DateTime.Now.DayOfWeek.ToString();
            CurrentDay.ToLower();
            foreach (string DayCheck in DaysOff)
            {
                DayCheck.ToLower();
                if (CurrentDay == DayCheck)
                {
                    return (true);
                }
            }
            return (false);
        }
    }
    // Example usage code:
    class Program
    {
        List<string> DaysOff = List<string>();
        DaysOff.Add("Saturday");  // Add some values to our list.
        DaysOff.Add("Sunday");
        DayOffChecker CheckToday = new DayOffChecker();
        if(CheckToday.CheckDays(DaysOff))
        {
            Console.WriteLine("You're Off Today!!!");
        }
    }
