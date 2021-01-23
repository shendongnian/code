    static void Main(string[] args)
    {
        const int BoxWidth = 40;
        Console.WriteLine( BoxStartEnd(BoxWidth) );
        Console.WriteLine( BoxLine(BoxWidth, "Does this work: {0} {1}", 42, 64) );
        Console.WriteLine( BoxLine(BoxWidth, " -->Yep<--") );
        Console.WriteLine( BoxStartEnd(BoxWidth) );
        Console.Read();    
    }
