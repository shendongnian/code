    static void Main()
    {
        Console.Write(ValidateDate("ddd dd MMM h:mm tt yyyy", "Wed 10 Jul 9:30 AM 2013"));
        Console.Read();
    }
    public static bool ValidateDate(string format, string date)
    {
       DateTime dateTime;
       if (DateTime.TryParseExact(date, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
       {
           Console.WriteLine(dateTime);
           return true;
       }
       else
       {
           Console.WriteLine("Invalid date or format");
           return false;
       }
    }
