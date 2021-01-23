    public static Months DetermineMonth(int userInput)
    {
        Months temp = (Months)userInput;
        return Enum.IsDefined(typeof(Months), temp) ? temp : Months.None; 
    }
