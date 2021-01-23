    class Program
    {
        static List<ITest> list;
        static void Main(string[] args)
        {
            list = new List<ITest>();
            // ...
            // initialize list 
            // ...
            foreach (ITest p in list)
                p.Test();
        }
    }
