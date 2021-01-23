    class Program
    {
        
        static System.Threading.Timer timer;
        static bool workAvailable = false;
        static int timeInMs = 5000;
        static object o = new object(); 
        static void Main(string[] args)
        {
            timer = new Timer((o) =>
                {
                    try
                    {
                        if (workAvailable)
                        {
                            // do the work,   whatever is required.
                            // if another thread is started use Thread.Join to wait for the thread to finish
                        }
                    }
                    catch (Exception)
                    {
                        // handle
                    }
                    finally
                    {
                        // only set the initial time, do not set the recurring time
                        timer.Change(timeInMs, Timeout.Infinite);
                    }
                });
            
            // only set the initial time, do not set the recurring time
            timer.Change(timeInMs, Timeout.Infinite);
        }
