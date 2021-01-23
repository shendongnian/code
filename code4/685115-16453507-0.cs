    public class AnniversaryConcept
    {
        public const int DAYS_TO_LOOK_FORWARD = 5;
    
        public void Run()
        {
            Console.WriteLine(AnniversaryMessage(DateTime.Now.AddDays(6).AddYears(-1)));
            Console.WriteLine(AnniversaryMessage(DateTime.Now.AddDays(5).AddYears(-1)));
            Console.WriteLine(AnniversaryMessage(DateTime.Now.AddDays(4).AddYears(-1)));
            Console.WriteLine(AnniversaryMessage(DateTime.Now.AddDays(3).AddYears(-1)));
            Console.WriteLine(AnniversaryMessage(DateTime.Now.AddDays(2).AddYears(-1)));
            Console.WriteLine(AnniversaryMessage(DateTime.Now.AddDays(1).AddYears(-1)));
            Console.WriteLine(AnniversaryMessage(DateTime.Now.AddDays(0).AddYears(-1)));
            Console.WriteLine(AnniversaryMessage(DateTime.Now.AddDays(-1).AddYears(-1)));
            Console.WriteLine(AnniversaryMessage(DateTime.Now.AddDays(-2).AddYears(-1)));
            Console.WriteLine(AnniversaryMessage(DateTime.Now.AddDays(-3).AddYears(-1)));
    
            Console.WriteLine(AnniversaryMessage(DateTime.Now.AddDays(2).AddYears(-1)));
            Console.WriteLine(AnniversaryMessage(DateTime.Now.AddDays(2).AddYears(-2)));
            Console.WriteLine(AnniversaryMessage(DateTime.Now.AddDays(2).AddYears(-3)));
            Console.WriteLine(AnniversaryMessage(DateTime.Now.AddDays(2).AddYears(-4)));
        }
    
        public string AnniversaryMessage(DateTime originalDate)
        {
            TimeSpan dateDifference = DateTime.Now - originalDate;
    
            // Date is in the future. Can't be anniversary.
            if (dateDifference.Ticks < 0)
            {
                return null;
            }
    
            // Not close enough to an annivesary.
            if ((dateDifference.Days % 365) < (365 - DAYS_TO_LOOK_FORWARD))
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
    
            return string.Format("{0} year anniversary in {1} days.", (dateDifference.Days / 365) + 1, (365 - (dateDifference.Days % 365) + leapYears));
        }
    }
