    class Test
    {
        delegate void update();
        static event update updateEvent;
        static void Main(string[] args)
        {
            Console.WriteLine("Parent thread: " + Thread.CurrentThread.ManagedThreadId);
            updateEvent += new update(Test_updateEvent);
            var t = Task.Factory.StartNew(
                () =>
                {
                    Console.WriteLine("Task thread: " + Thread.CurrentThread.ManagedThreadId);
                    updateEvent();
                });
            t.Wait();
        }
        static void Test_updateEvent()
        {
            Console.WriteLine("Event thread: " + Thread.CurrentThread.ManagedThreadId);
        }
    }
