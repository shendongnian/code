    static class Program
    {
        static void Main(string[] args)
        {
            var value = 0;
            value = value.GetNext(); // Compiler error
        }
    
        static int GetNext(this int i)
        {
            return i + 1;
        }
    }
