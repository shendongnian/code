    class Program
    {
        class Test
        {
            internal object lockValue = new Object();
            internal bool value = false;
        }
        static void Main(string[] args)
        {
            Test test = new Test();
            //Option 1
            ThreadPool.QueueUserWorkItem((s) =>
            {
                lock (test.lockValue)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(((Test)s).value);
                }
            }, test);
            //Option 2
            ThreadPool.QueueUserWorkItem((s) =>
            {
                lock (test.lockValue)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(test.value);
                }
            });
            Thread.Sleep(100);
            lock (test.lockValue)
            {
                test.value = true;
            }
            Console.ReadLine();
        }
    }
