    class Program
    {
        static void Main(string[] args)
        {
        #if (DEBUG)
            Debugger.Log(0, "category", "msg");
        #endif
        }
    }
