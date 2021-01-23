    class Program
    {
        static void Main()
        {
           var methods = new Dictionary<string, Func<int>>
               {
                   { "001", DoMethod1 }
               };
        }
        static int DoMethod1()
        {
            return 1;
        }
    }
