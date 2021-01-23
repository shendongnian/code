        internal class Test2 : Test
        {
        }
    
        internal class Test : Program
        {
        }
    
        internal class Program
        {
            private static void Main(string[] args)
            {
                foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
                {
                    if (typeof(Program).IsAssignableFrom(type))
                    {
                        if (type.BaseType == typeof(Program))
                        {
                            Console.WriteLine("strict inheritance for {0}", type.Name);
                        }
                        else
                        {
                            Console.WriteLine("no strict inheritance for {0}", type.Name);
                        }
                    }
                }
    
                Console.Read();
            }
        }
----------
    no strict inheritance for Program
    strict inheritance for Test
    no strict inheritance for Test2
