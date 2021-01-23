    using System;
    using System.Collections;
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList datalist = new ArrayList 
                {
                    "asd",
                    "surname",
                    "dfg"
                };
            Console.WriteLine(datalist.IndexOf("surname") != -1 ? "Found" : "Not found");
            Console.ReadKey(true);
        }
    }
