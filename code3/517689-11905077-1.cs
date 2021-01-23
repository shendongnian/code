        static void Main(string[] args)
        {
            Console.Write("Process B");
            Task.Factory.StartNew(() =>
            {
                var readyEvent = new EventWaitHandle(false, EventResetMode.ManualReset, "Process B Ready");
                var doneEvent = new EventWaitHandle(false, EventResetMode.ManualReset, "Process A Finished");
                // Signal that process B is ready
                readyEvent.Set();
                // Wait for process A to complete...
                doneEvent.WaitOne();
                Console.Write("Process B Completed!");
            });
            Console.Read();
        }
