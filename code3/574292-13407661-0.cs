using System;
namespace ConsoleApplication1
{
    class Program
    {
        private const int MilliSecondsToWait = 30000;
        private static System.Timers.Timer EmailTimer;
        static void Main(string[] args)
        {
            EmailTimer = new System.Timers.Timer(MilliSecondsToWait);
            EmailTimer.Elapsed += EmailTimer_Elapsed;
            EmailTimer.Start();
            Console.WriteLine("Press Enter to quit.");
            Console.ReadLine();
            // if you hit enter, the app will exit.  It is possible for the user to exit the app while a mail download is occurring.  
            // I'll leave it to you to add some flags to control that situation (just trying to keep the example simple)
        }
        private static void EmailTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // stop the timer to prevent overlapping email downloads if the current download takes longer than MilliSecondsToWait
            EmailTimer.Stop();
            try
            {
                Console.WriteLine("Email Download in progress.");
                // get your email.
            }
            catch (System.Exception ex)
            {
            	// handle any errors -- if you let an exception rise beyond this point, the app will be terminated.
            }
            finally
            {
                // start the next poll
                EmailTimer.Start();
            }
        }
    }
}
