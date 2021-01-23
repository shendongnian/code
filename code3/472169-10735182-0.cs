    long timeA = now.ToBinary();
    long timeB = new DateTime(
        now.Year, 
        now.Month, 
        now.Day, 
        now.Hour, 
        now.Minute, 
        now.Second, 
        now.Millisecond, 
        DateTimeKind.Local).ToBinary();
    
    Console.WriteLine(timeA);
    Console.WriteLine(timeB);
