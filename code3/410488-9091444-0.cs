        static void Main(string[] args)
        {
            try
            {
                Mutex mutex = Mutex.OpenExisting(@"Global\_MSIExecute");
                if (!mutex.WaitOne(TimeSpan.FromSeconds(5), false))
                {
                    Console.WriteLine("Installation in progress!");
                    return;
                }
            }
            catch (AbandonedMutexException)
            {
                Console.WriteLine("Mutex was abandoned");
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                Console.WriteLine("MSI installer not running");
            }
            // Perform operation here
        }
