    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace StackOverflowDemoCode
    {
        class Program
        {
            static void Main()
            {
                // Dictionary string
                const string s = @"Casual Leave:12-Medical Leave :13-Annual Leave :03";
                const int lengthOfValue = 2;
    
                // Convert to make sure we find the key regardless of case
                string sUpper = s.ToUpper();
                string key = @"Casual Leave:".ToUpper();
    
                // Location of the value
                // Start of the key plus its length will put us at the end
                int i = sUpper.IndexOf(key) + key.Length;
                
                // pull value from original string, not UPPERCASE string
                string d = s.Substring(i, lengthOfValue);
                Console.WriteLine(d);
                Console.ReadLine();
            }
        }
    }
