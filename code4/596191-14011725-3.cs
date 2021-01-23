    class Program
    {
        static int workingCounter = 0;
        static int workingLimit = 10;
        static void Main(string[] args)
        {
            foreach (string file in Directory.GetFiles("C:\\Temp"))
            {
                //wait until you are allowed to start new thread
                //since limit is 10 threads at the same time
                while (workingCounter >= workingLimit)
                {
                    Thread.Sleep(100);
                }
                workingCounter += 1;
                ParameterizedThreadStart pts = new ParameterizedThreadStart(ProcessFile);
                Thread th = new Thread(pts);
                th.Start(file);
            }
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
            }
            finally
            {
                Interlocked.Decrement(ref workingCounter);
            }
        }
    }
