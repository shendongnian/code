    public static int DetermineDaysInMonth(int userInput)
    {
        if (!((Months[])Enum.GetValues(typeof(Months))).Contains((Months)userInput)
            return 0;
        else return DateTime.DaysInMonth(DateTime.Today.Year, userInput);
    }
