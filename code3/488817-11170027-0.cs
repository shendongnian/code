    DateTime date1 = new DateTime(2008, 6, 1, 7, 47, 0);
    Console.WriteLine(date1.ToString());
    
    // Get date-only portion of date, without its time.
    DateTime dateOnly = date1.Date;
    // Display date using short date string.
    Console.WriteLine(dateOnly.ToString("d"));
