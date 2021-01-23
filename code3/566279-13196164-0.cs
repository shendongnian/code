    [STAThread]
    static void Main(string[] args)
    {
        if (args != null && args.Length > 0)
        {
            Form1 f1 = new Form1();
            if (f1.IsLive) //Not sure if this is a default or set in constructor??
            {
                f1.OnLaunch(); // tests DB connection and reads and updates the expiry date list.
                if (args[0] == "FullStats")
                    f1.FullStatsDataPump();
                else if (args[0] == "OptionsStats")
                {
                    f1.OptionsStatsTimer_Tick(null, null);
                    f1.OptionsStatsTimer.Start();
                }
                else if (args[0] == "OptionsTraded")
                {
                    f1._optionsTradedTimer_Tick(null, null);
                    f1.OptionsTradedTimer.Start();
                }
                else
                {
                    EmailManager.InvalidInputArgument(args[0]);
                    return;
                }
                Application.Run(f1);
            }
        }
