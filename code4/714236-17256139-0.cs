    //Add Using Statement
    using System.Windows.Threading;
    //Create Timer
    DispatcherTimer mytimer;
    //Setup Timer
    myTimer = new DispatcherTimer();
    myTimer.Interval = System.TimeSpan.FromSeconds(10);
    myTimer.Tick += myTimer_Tick;
    // When you type the +=, this method skeleton should come up
    // automatically. But type this in if it doesn't.
    void myTimer_Tick(object sender, EventArgs e)
    {
        //This runs when ever the timer Goes Off (In this case every 10 sec)
    }
    //Run Timer
    myTimer.Start()
    //Stop Timer
    myTimer.Stop()
