    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace Prac6Question2
    {
        class Program
        {
           static void Main(string[] args)
            {
                double testMark;
                string result;
    
                testMark = GetTestMark();
                result = DetermineResult(testMark);
                Display(testMark, result); 
    
            }
    
            static double GetTestMark()
            {
                double testMark;
                Console.WriteLine("Your test result: ");
                testMark = double.Parse(Console.ReadLine());
                return testMark;
    
            }
    
            static string DetermineResult(double testMark)
            {
                string result;
                if (testMark < 50)
                    result = "Fail";
                else
                    result = "Pass";
    
                return result;
    
            }
    
            static void Display(double testMark, string result)
            {
                Console.WriteLine("Your test result: {0}", result);
                Console.ReadLine();
            }
    
        }
    
    }
