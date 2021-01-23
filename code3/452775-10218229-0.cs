    using System;
    
    public enum Operations_PerHourType //   : byte
    {
        Holes = 1,
        Pieces = 2,
        Sheets = 3,
        Strips = 4,
        Studs = 5
    }
    
    class Program
    {
        static void Main()
        {
       	    long before = GC.GetTotalMemory(false);
    	    var enums = new Operations_PerHourType[10000];
    	    long after = GC.GetTotalMemory(false);
    	    Console.WriteLine(after - before);
            // output  (byte): 12218 (I'm using Mono 2.8)
            // output (Int32): 40960
        }
    }
