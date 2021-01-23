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
                            // do the work
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
