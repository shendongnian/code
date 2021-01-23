    class howmanytimescallingafunction
         {
            public static int i = 0;
            public List<string> fun()
            {
                List<string> list = new List<string> { "A", "B", "C" };
                i++;
                return list;
            }
            public void func()
            {
                Console.WriteLine(fun()[0]);
                Console.WriteLine(i);
                Console.WriteLine(fun()[1]);
                Console.WriteLine(i);
                Console.WriteLine(fun()[2]);
                Console.WriteLine(i);
            }
        }
