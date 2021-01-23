    static void Main(string[] args)
        {
            Thread thready = new Thread(DoSomething);
            thready.IsBackground = true;
            thready.Start();
        }
        static void DoSomething()
        {
            while (true)
            {
                Console.Write("thread's looping \n");
            }
        }
