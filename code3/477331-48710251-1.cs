    public class Test
    {
        // ctor #1
        public Test() : this(5) // this jumps to the ctor #2
        {
            Console.WriteLine("no params");
        }
        
        // ctor #2
        public Test(int i) : this("Hi") // this jumps to the ctor #3
        {
            Console.WriteLine("integer=" + i.ToString());
        }
        // ctor #3
        public Test(string str) // this ctor will be run first
        {
            Console.WriteLine("string=" + str);
        }
    }
