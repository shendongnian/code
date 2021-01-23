    public static void Start()
    {
        if (Application.Current == null)
        {
            // create the Application object
            App a = new App();
            var l = a.Resources["Locator"] as Locator;
            // do something with l
            a.Run();
        }
        else
        {
            var locator = new Locator();
            // do something with l
            Application.Current.Resources.Remove("Locator");
            Application.Current.Resources.Add("Locator", locator);
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
