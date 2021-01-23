    int days = 1;
    
    DateTime n = DateTime.Now;
    
    Console.WriteLine( "Now using a fixed known format for tests");
    Console.WriteLine( "{0:yyyy MM dd}" , n);
    Console.WriteLine();
    
    DateTime Date1 = n.Subtract(new TimeSpan(days, 0, 0, 0));
    
    Date1.Dump();
    
    
    DateTimeFormatInfo dtfi = CultureInfo.CurrentUICulture.DateTimeFormat;
    
    Console.WriteLine("machines short date pattern");
    Console.WriteLine( dtfi.ShortDatePattern );
    Console.WriteLine("{0:d}" , Date1);
    Console.WriteLine();
    
    Console.WriteLine("machines long date pattern");
    Console.WriteLine( dtfi.LongDatePattern );
    Console.WriteLine("{0:D}" , Date1);
