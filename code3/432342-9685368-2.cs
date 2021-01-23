    class Program
    {
        static void Main(string[] args)
        {
            myFunc(1, 2, 3);
            myFunc(new int[] { 1, 2, 3 });
        }
        static void myFunc(params object[] args)
        {
            if (args.Length == 1 && (args[0] is int[]))
            {
                // called using myFunc(new int[] { 1, 2, 3 });
            }
            else
            {
                //called using myFunc(1, 2, 3), or other
            }
        }
    }
