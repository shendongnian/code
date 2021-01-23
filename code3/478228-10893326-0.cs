     DateTime dt = DateTime.ParseExact(date1,"ddMMyy",System.Globalization.CultureInfo.CurrentCulture);
    // Get date-only portion of date, without its time.
    DateTime dateOnly = dt.Date;
    // Display date using short date string.
    Console.WriteLine(dateOnly.ToString("d"));
