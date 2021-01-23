    public class Program
    {
        private bool stopThread;
        public void Test()
        {
            bool toggle = true;
            while (!stopThread) // Read stopThread which is not marked as volatile
            { 
              toggle = !toggle;
            }  
            Console.WriteLine("Stopped.");
        }
        private static void Main()
        {
            Program program = new Program();
            Thread thread = new Thread(program.Test);
            thread.Start();
            Console.WriteLine("Press a key to stop the thread.");
            Console.ReadKey();
            Console.WriteLine("Waiting for thread.");
            program.stopThread = true;
            thread.Join();  // Waits for the thread to stop.
        }
    }
