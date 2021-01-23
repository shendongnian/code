    using System;
    using System.Collections.Generic;
    namespace Demo
    {
        class Program
        {
            void test()
            {
                var entities = new List<string> { "pencil", "smartboard", "tabletc" };
                for (int x = 0; x < entities.Count; x++)
                    Console.WriteLine(entities[x] + " " +  "a pencil g smartboard tabletc pencil ".IndexOf(entities[x]));
            }
            static void Main()
            {
                new Program().test();
            }
        }
    }
