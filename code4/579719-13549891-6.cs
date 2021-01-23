    public static class Country
        {
            private static string _name;
    
            public static string Name
            {
                get { return _name; }
                set
                {
                    _name = value;
                    Console.WriteLine(value); /* test */
                }
            }
        }
