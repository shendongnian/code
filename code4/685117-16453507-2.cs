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
            TimeSpan dateDifference = DateTime.Now - originalDate;
    
            // Date is in the future. Can't be anniversary.
            if (dateDifference.Ticks < 0)
            {
                return null;
            }
    
            int leapYears = 0;
            for (int i = 0; i < (dateDifference.Days / 365); i++)
            {
                if (DateTime.IsLeapYear(DateTime.Now.AddYears(-(i + 1)).Year))
                {
                    leapYears++;
                }
            }
    
            // Not close enough to an anniversary.
            if (((dateDifference.Days - leapYears) % 365) < (365 - DAYS_TO_LOOK_FORWARD))
            {
                return null;
            }
    
            return string.Format("{0} year anniversary in {1} days.", (dateDifference.Days / 365) + 1, 365 - ((dateDifference.Days - leapYears) % 365));
        }
    }
