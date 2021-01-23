    using System;
    using System.Collections.Generic;
    using System.Linq;
     
    public class Test
    {
            public static string[] firstNames = {"Mark", "Mike" };
            public static string[] lastNames = {"Watson", "Wilson"};
            
            public static void Main (string[] args)
            {
     
                    var fullnames = 
                            from fn in firstNames
                            from ln in lastNames
                            select new { Fullname = fn + " " + ln };
                            
                    foreach(var person in fullnames) {
                         Console.WriteLine (person.Fullname);
                    }
                            
          }
    }
