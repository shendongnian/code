    public class AnniversaryConcept : IConceptable
    {
        public const int DAYS_TO_LOOK_FORWARD = 5;
    
        public void Run()
        {
            Console.WriteLine(AnniversaryMessage(GetPastDate(6, -1)));
            Console.WriteLine(AnniversaryMessage(GetPastDate(5, -1)));
            Console.WriteLine(AnniversaryMessage(GetPastDate(4, -1)));
            Console.WriteLine(AnniversaryMessage(GetPastDate(3, -1)));
            Console.WriteLine(AnniversaryMessage(GetPastDate(2, -1)));
            Console.WriteLine(AnniversaryMessage(GetPastDate(1, -1)));
            Console.WriteLine(AnniversaryMessage(GetPastDate(0, -1)));
            Console.WriteLine(AnniversaryMessage(GetPastDate(-1, -1)));
            Console.WriteLine(AnniversaryMessage(GetPastDate(-2, -1)));
            Console.WriteLine(AnniversaryMessage(GetPastDate(-3, -1)));
    
            Console.WriteLine(AnniversaryMessage(GetPastDate(2, -1)));
            Console.WriteLine(AnniversaryMessage(GetPastDate(2, -2)));
            Console.WriteLine(AnniversaryMessage(GetPastDate(2, -3)));
            Console.WriteLine(AnniversaryMessage(GetPastDate(2, -4)));
            Console.WriteLine(AnniversaryMessage(GetPastDate(2, -5)));
            Console.WriteLine(AnniversaryMessage(GetPastDate(2, -6)));
            Console.WriteLine(AnniversaryMessage(GetPastDate(2, -7)));
            Console.WriteLine(AnniversaryMessage(GetPastDate(2, -8)));
            Console.WriteLine(AnniversaryMessage(GetPastDate(2, -9)));
            Console.WriteLine(AnniversaryMessage(GetPastDate(2, -10)));
            Console.WriteLine(AnniversaryMessage(GetPastDate(2, -11)));
            Console.WriteLine(AnniversaryMessage(GetPastDate(2, -12)));
        }
    
        private DateTime GetPastDate(int daysOffset, int yearsOffset)
        {
            return new DateTime(DateTime.Now.Year + yearsOffset, DateTime.Now.Month, DateTime.Now.Day + daysOffset);
        }
    
    public string AnniversaryMessage(DateTime originalDate)
    {
        if (originalDate > DateTime.Now)
        {
            return null;
        }
    
        int dayDifference = (new DateTime(DateTime.Now.Year, originalDate.Month, originalDate.Day).Date
                                        - DateTime.Now.Date).Days;
    
        // Already past this date.
        if (dayDifference < 0 || dayDifference > DAYS_TO_LOOK_FORWARD)
        {
            return null;
        }
    
        return string.Format("{0} year anniversary in {1} days.", 
            DateTime.Now.Year - originalDate.Year, 
            dayDifference);
    }
    }
