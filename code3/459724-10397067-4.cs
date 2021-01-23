    using System;
     
    using System.Collections.Generic;
     
    public class Test
    {
            public static void Main()
            {
                 var conditions = new List<string>();
                 conditions.Add("Lastname = 'Lennon'");
                 conditions.Add("Firstname = 'John'");
                 conditions.Add("Age = 40");
     
                 Console.WriteLine(string.Join(" OR ", conditions.ToArray() ));
            }
    }
