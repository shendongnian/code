    static void Main(string[] args)
    {
        while (true)
        {
            // There is no need to restart you application to get latest values.
            // Calling this method forces the reading of the setting directly from the config.
            ConfigurationManager.RefreshSection("appSettings");
            Console.WriteLine(ConfigurationManager.AppSettings["myKey"]);
            // Or if you're using the Settings class.
            Properties.Settings.Default.Reload();
            Console.WriteLine(Properties.Settings.Default.MyTestSetting);
            // Sleep to have time to change the setting and verify.
            Thread.Sleep(10000);
        }
    }
