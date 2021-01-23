    private static pingerform myPingerform = null;
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        myPingerform = new pingerform();
        Thread thread = new Thread(new ThreadStart(UpdateTextBox));
        thread.Start();
        Application.Run(myPingerform);
    }
    
    private static void UpdateTextBox()
    {
        while (true)
        {
            myPingerform.textBox2.Text = DateTime.Now.Ticks.ToString();
            Thread.Sleep(1000);
        }
    }
