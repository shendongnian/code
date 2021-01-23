    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer(1);
            timer.Elapsed += timer_Elapsed;
            timer.AutoReset = false;
            timer.Enabled = true;
        }
        static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Timer timer = (Timer)sender;
            try
            {
                //  do the checks here
            }
            finally
            {
                //  re=enable the timer to check again very soon
                timer.Enabled = true;
            }
        }
    }
