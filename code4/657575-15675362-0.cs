    public enum Cases { Case1, Case2, Case3 };
    class Program
    {
        private static bool Test1(int test) { return test == 1; }
        private static bool Test2(int test) { return test == 2; }
        private static bool Test3(int test) { return test == 3; }
        public static void Main()
        {
            RunTest(Cases.Case1);
            RunTest(Cases.Case2);
            RunTest(Cases.Case3);
            Console.ReadLine();
        }
        private static void RunTest(Cases testCase)
        {
            var list = new List<int> {1, 2, 3};
            Func<int, bool> del;
            switch (testCase)
            {
                case Cases.Case1:
                    del = Test1;
                    break;
                case Cases.Case2:
                    del = Test2;
                    break;
                case Cases.Case3:
                    del = Test3;
                    break;
                default:
                    throw new InvalidDataException();
            }
            list.ForEach( i => Console.WriteLine(del(i) ? i.ToString() : "--")  );
        }
    }
