    public class Test
    {
        public Test() : this(5)
        {
            Console.WriteLine("no params");
        }
        public Test(int i) : this("Hi")
        {
            Console.WriteLine("integer=" + i.ToString());
        }
        public Test(string str)
        {
            Console.WriteLine("string=" + str);
        }
    }
