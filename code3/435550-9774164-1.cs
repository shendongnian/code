    class Program
    {
        static void Main(string[] args)
        {
            string[] val;
            foo(out val);
            Console.WriteLine(string.Join(",", val));
            // Output: 1, 2
            bar(ref val);
            Console.WriteLine(string.Join(",", val));
            // Output: modified, 2
            bar2(val);
            Console.WriteLine(string.Join(",", val));
            // Output: modified again, 2
            Console.Read();
        }
        static void foo(out string[] temp)
        {
            temp = new string[]{"1", "2"};
        }
        static void bar(ref string[] temp)
        {
            temp[0] = "modified";
        }
        static void bar2(string[] temp)
        {
            temp[0] = "modified again";
        }
    }
