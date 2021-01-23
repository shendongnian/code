    public Form1()
    {
        InitializeComponent();
        Timer timer1 = new Timer(); //Initialize a new Timer of name timer1
        timer1.Tick += new EventHandler(timer1_Tick); //Link the Tick event with timer1_Tick
        timer1.Start(); //Start the timer
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        if (DateTime.Now.Hour == 23 && DateTime.Now.Minute == 00 && DateTime.Now.Second == 00) //Continue if the current time is 23:00:00
        {
            Application.Exit(); //Close the whole application
            //this.Close(); //Close this form only
        }
    }
