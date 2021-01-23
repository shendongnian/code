    public class DesignChecker 
    {
        private static DateTime lastCallTime = Datetime.MinValue;
        private static int minTimeSpan = 500; //set this threshold to your own needs
        public static void designChecker()
        {
            DateTime curTime = DateTime.UtcNow;
            TimeSpan span = curTime - lastCallTime;
            if (span.TotalMilliseconds < minTimeSpan)
            {
                lastCallTime = curTime;
            }
            else
            {
                lastCallTime = curTime;
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        doDesignCheck();
                    });
            }
        }
    }
