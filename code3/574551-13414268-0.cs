    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    
    namespace test
    {
        class Program
        {
            public static void Main()
            {
    
                List<string> val1 = new List<string> {
    			  "File_1.txt","File_2.txt","File_1_Over.txt","File_2_Item.txt","File_1_Over.bat",
    				"File_1_Over_test.bat","File_2_Standard.bat","File_2_Item_Standard.bat"
    			};
    
                var val = val1
                    .GroupBy(f => Path.GetFileNameWithoutExtension(f)) //group by filename
                    .OrderBy(group => group.Key); //here's the "Sort"
    
                foreach (var group in val)
                {
                    var q = group.OrderByDescending(f => Path.GetExtension(f)); //order the filenames for outputting
                    foreach (var f in q)
                    {
                        Console.WriteLine(f);
                    }
                }
    
            }
        }
    }
