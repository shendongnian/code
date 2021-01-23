    using System;
     
    public class Test
    {
            public static void Main()
            {
               Random randObj = new Random();
               var number = randObj.NextDouble( ) * 10000000000000;
               Console.WriteLine( number ); 
            }
    }
...
    input: no
    output:
    6426401076105.61
