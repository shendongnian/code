        static void Main(string[] args)
        {
            Console.Write("Process A");
            Task.Factory.StartNew(() =>
            {
                var readyEvent = new EventWaitHandle(false, EventResetMode.ManualReset, "Process B Ready");
                var doneEvent = new EventWaitHandle(false, EventResetMode.ManualReset, "Process A Finished");
                // Wait for process B to be ready...
                readyEvent.WaitOne();
                // Do some work...
                Console.Write("Process A Completed!");
                // Signal that the process is complete
                doneEvent.Set();
            });
            Console.Read();
        }
