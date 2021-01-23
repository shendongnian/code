    class Program
    {
        static void Main(string[] args)
        {
            var bar = MyFuncConverter<int, string, string>.ConvertFunction(Test);
            Console.WriteLine("Invoking {0} {1}",
                "Test(10, \"abc\")", Test(10, "abc"));
            Console.WriteLine("Invoking {0} {1}",
                "bar.Invoke(\"abc\", 10)", bar.Invoke("abc", 10));
        }
        private static string Test(int arg1, string arg2)
        {
            return String.Format("First arg = {0}, second arg = {1}. Or is it...?"
                , arg1, arg2);
        }
    }
