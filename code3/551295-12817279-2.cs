    class Test
        {
            public static string x = EchoAndReturn("a");
            public static string y = EchoAndReturn("b");
            public static string EchoAndReturn(string s)
            {
                Console.WriteLine(s);
                return s;
            }
        }
