        static void Main(string[] args)
        {
            var method = typeof(Program).GetMethod("test");
            string parameterTypes = string.Join(", ", method.GetParameters().Select(x=>x.ParameterType));
            Console.WriteLine("{0} ({1})",                             
                              method.Name,
                              parameterTypes);
            
            Console.ReadKey();
        }
        
        public void test(int a, string c)
        {
        }
    }
