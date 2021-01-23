    var now = DateTime.Now;
    long timeA = now.ToBinary();
    long timeB = new DateTime(now.Ticks, now.Kind).ToBinary();;
    
    Console.WriteLine(timeA);
    Console.WriteLine(timeB);
