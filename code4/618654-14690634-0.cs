    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleHelloWorld
    {
    
       
        public static class Program
        {
            public static class Hello
            {
                public static string words = "Hello World";
            }
           public static void Main(string[] args)
           {
               string word = ConsoleHelloWorld.Program.Hello.words;
    
               Console.WriteLine(word);
               Console.ReadLine();
    
           }
       }
    }
