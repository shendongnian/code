    using System;
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                string text = "master$maincontentplaceholder$ucsearchresults$ucfilter$hdnvalue";
                string id = text.Substring(text.LastIndexOf("$") + 1);
                Console.WriteLine(id);
                Console.ReadLine();
            }
        }
    }
