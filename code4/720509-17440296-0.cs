    using System.IO;
    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main()
        {
            string input1 = "C0123456"; 
            // input1 starts with C0 and ends with 4 digit , allowing any number of                 
            // characters/digit in between
            string input2 = "C01234";
            // input2 starts with C0 and ends with 4 digit , without                
            // characters/digit in between
            String pattern1=@"\b[C][0][a-z A-Z 0-9]*\d{4}\b";
            String pattern2=@"\b[C][0]\d{4}\b";
            Match m = Regex.Match(input1, pattern1);
            if(m.Success)
            Console.WriteLine("Pattern1 matched input1 and the value is : "+m.Value);
            m = Regex.Match(input2, pattern2);
            if(m.Success)
            Console.WriteLine("Pattern2 matched input2 and the value is : "+m.Value);
              m = Regex.Match(input1, pattern2);
            if(m.Success)
            Console.WriteLine("Pattern2 matched input1 and the value is : "+m.Value);
              m = Regex.Match(input2, pattern1);
            if(m.Success)
            Console.WriteLine("Pattern1 matched input2 and the value is : "+m.Value);
            
    
        }
    }
