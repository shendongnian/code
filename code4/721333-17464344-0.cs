    using System;
    using System.Text.RegularExpressions;
     
    class Test {
        static void Main() {
            string filename = "Try123_Enrollment_20130102_1200.xml";
            Regex pattern = new Regex(@"^[A-Za-z0-9]+_Enrollment_[0-9]{8}_[0-9]{4}\.xml$");
            if (pattern.IsMatch(filename))
            {
                Console.WriteLine("Matched");
            }
        }
    }
