    using System.Globalization;
    static void Main(string[] args)
    {
        Console.Write("Enter a Number to find out what Month it is: ");
        int userInput = Convert.ToInt16(Console.ReadLine());
        if(userInput > 0 && userInput < 13)
        {            
             string monthName = CultureInfo.CurrentCulture.DayTimeFormat.MonthNames[userInput-1];
             int daysInMonth = DateTime.DaysInMonth(2013, userInput);
             ......
 
        }
    }
