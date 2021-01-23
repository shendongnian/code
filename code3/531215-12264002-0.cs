    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication
    {
        internal class Program
        {
            private static void Main()
            {
                //table to mimik your structure
                var table = new List<string[]>(new[]
                    {
                        new[] {"TC001", null, null, "Passed"},
                        new[] {"TC002", null, null, "Passed"},
                        new[] {"TC003", null, null, "Passed"},
                        new[] {"TC003", null, null, "Passed"},
                        new[] {"TC003", null, null, "Failed"},
                        new[] {"TC004", null, null, "Passed"}
                    });
    
                //calculate
                var grouped = from itemArray in table
                              //group by the testid
                              group itemArray by itemArray[0]
                              into g select new
                                  {
                                      TestCaseId = g.Key,
                                      //add up the passes and fails
                                      PassedCount = g.Count(i => i[3] == "Passed"),
                                      FailedCount = g.Count(i => i[3] == "Failed")
                                  };
    
                //enumerate and output to screen
                foreach (var group in grouped)
                {
                    Console.WriteLine("TestCase {0} Passed: {1}, Failed: {2}",
                                      group.TestCaseId, group.PassedCount,
                                      group.FailedCount);
                }
                Console.ReadLine();
            }
        }
    }
