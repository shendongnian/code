    public enum Months : int
    {
        None = 0,
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    };
    public class Program
    {
        public const string NEWLINE = "\n";     //constant for new line
        static void Main(string[] args)
        {
            try
            {
                //prompt user for month number.
                Console.Write("Enter a Number to find out what Month it is: ");
                //convert users answer to integer
                int userInput = Convert.ToInt16(Console.ReadLine());
                //declare and initalise
                int daysInMonth = 0;
                Months answer;
                //call relevent calculation methods
                answer = DetermineMonth(userInput);
                if (answer == Months.None) 
                {
                    Console.WriteLine("Please enter a value between 1 and 12");
                    return;
                }
                daysInMonth = DetermineDaysInMonth(answer);
                //Write users answer to screen
                Console.WriteLine(answer);
                //Prompt user, whether they want to know number of days in the
                //month
                Console.Write("Would you like to know the number of days in {0}: ", answer);
                //assign users answer to variable
                string userAnswer = Console.ReadLine();
                //Output answer if needed.
                if (userAnswer == "yes".Trim().ToLower())
                {
                    Console.WriteLine("The number of days in {0} is: {1}", answer, daysInMonth.ToString());
                }
                else if (userAnswer == "no".Trim().ToLower())
                {
                    Console.WriteLine(NEWLINE);
                    Console.WriteLine("You answered No, Have a good day!");
                }
                else
                    Console.WriteLine("Please answer yes or no.");
                Console.ReadLine(); //Pauses screen for user
            }
            //catch any errors.
            catch (Exception err)
            {
                Console.WriteLine("Error" + err.Message);
            }
        }
        /// <summary>
        /// Determines What month the use enters and returns string value
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns>returns the month as string</returns>
        public static Months DetermineMonth(int userInput)
        {
            switch (userInput)
            {
                case 1:
                    return Months.January;
                case 2:
                    return Months.February;
                case 3:
                    return Months.March;
                case 4:
                    return Months.April;
                case 5:
                    return Months.May;
                case 6:
                    return Months.June;
                case 7:
                    return Months.July;
                case 8:
                    return Months.August;
                case 9:
                    return Months.September;
                case 10:
                    return Months.October;
                case 11:
                    return Months.November;
                case 12:
                    return Months.December;
            }
            return Months.None;
        }
        /// <summary>
        /// Determines how many days is in selected month as integer
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns>returns how many days in month</returns>
        public static int DetermineDaysInMonth(Months userInput)
        {
            switch (Convert.ToInt32(userInput))
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 2:
                    return 28;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
            }
            return 0;
        }
    }
