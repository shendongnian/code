     class Program
        {
            static void Main(string[] args)
            {
                var test = new Test();
                var tests = new List<Test>()
                    {
                        new Test() {A = "A-1.1", B = "B-1.2", C = "C-1.3"}, 
                        new Test() {A = "A-2.1", B = "B-2.2", C = "C-2.3"}, 
                        new Test() {A = "A-3.1", B = "B-3.2", C = "C-3.3"}, 
                        new Test() {A = "A-4.1", B = "B-4.2", C = "C-4.3"}
                    };
    
                Console.WriteLine(String.Join<string>("\t", test.AsOrderColumns().Select(s => String.Format("{0}({1})", s.Key, s.Value))));
    
                foreach (var item in tests)
                {
                    Console.WriteLine(String.Join<object>("\t", item.AsOrderRow()));
                }
    
                Console.ReadKey();
    
            }
        }
