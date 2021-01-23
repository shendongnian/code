    class Program
    {
        static int workingCounter = 0;
        static int workingLimit = 10;
        static int processedCounter = 0;
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles("C:\\Temp");
            int checkCount = files.Length;
            foreach (string file in files)
            {
                //wait for free limit...
                while (workingCounter >= workingLimit)
                {
                    Thread.Sleep(100);
                }
                workingCounter += 1;
                ParameterizedThreadStart pts = new ParameterizedThreadStart(ProcessFile);
                Thread th = new Thread(pts);
                th.Start(file);
            }
            //wait for all threads to complete...
            while (processedCounter< checkCount)
            {
                Thread.Sleep(100);
            }
            Console.WriteLine("Work completed!");
        }
        static void ProcessFile(object file)
        {
            try
            {
                Console.WriteLine(DateTime.Now.ToString() + " recieved: " + file + " thread count is: " + workingCounter.ToString());
                //make some sleep for demo...
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                //handle your exception...
                string exMsg = ex.Message;
            }
            finally
            {
                Interlocked.Decrement(ref workingCounter);
                Interlocked.Increment(ref processedCounter);
            }
        }
    }
