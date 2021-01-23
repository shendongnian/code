    using System.Linq;
    using System.Threading;
    
    class MyApplication
    {
        [STAThread]
        static void Main(string[] args)
        {
            const string ARG_SHOWFORM = "ShowForm";
            const string ARG_STATS = "OptionsStats";
            const string ARG_TRADED = "OptionsTraded";
    
            if (args.Contains(ARG_SHOWFORM) || args.Length == 0) {
                Application.Run(new Form1());  //This will block until the form is closed.
    
                //Make sure all your supporting logic is placed into the Form.Loaded event on the form (i.e.
                //get it out of the Main() method).
    
                return;
            }
    
            if (args.Contains(ARG_STATS))
                OptionsStatsMethod();
    
            else if (args.Contains(ARG_TRADED))
                OptionsTradedMethod();
    
            else
                EmailManager.InvalidInputArgument(args[0]);
    
        }
    
        private void OptionsTradedMethod()
        {
            while (true) {
                if (downloadSuccessful) //Use a method here that returns a boolean if the download succeeded.
                    break;
                else
                    Thread.Sleep(DEFAULT_WAIT_TIME_MS);
            }
        }
    
        private void OptionsStatsMethod()
        {
            while (true) {
                if (downloadSuccessful)  //Use a method here that returns a boolean if the download succeeded.
                    break;
                else
                    Thread.Sleep(DEFAULT_WAIT_TIME_MS);
            }
        }
    }
