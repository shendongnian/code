    DateTime d1=DateTime.MinValue;
    DateTime d2=DateTime.MaxValue;
    TimeSpan span=d2-d1;
    Console.WriteLine
             ( "There're {0} days between {1} and {2}" , span.TotalDays, d1.ToString(), d2.ToString() );
