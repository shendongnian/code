    You may try with this: 
    
    using System.Globalization // namespace
    GregorianCalendar greg = new GregorianCalendar();
    DateTime DayYearMonth = new DateTime(1433, 10, 11, greg );
    
    Console.WriteLine(greg .GetDayOfMonth(DayYearMonth )); // 11
    Console.WriteLine(greg .GetYear(DayYearMonth )); // 1433
    Console.WriteLine(greg .GetMonth(DayYearMonth )); // 10
