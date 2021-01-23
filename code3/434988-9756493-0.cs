    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    
    namespace ByteTest
    {
    class Program
    {
        static void Main(string[] args)
        {
            char[] ac = { (char)(byte)97 }; //converts it to a character
            string s = new String(ac); //converts it to a string
            Console.WriteLine(s); //writes 'a'
            Thread.Sleep(10000); //displays the 'a' for 10 seconds, then finishes executing
        }
    }
    }
