    public Scheduler()
    {
        InitializeComponent();
        timer1.Tick += new EventHandler(timer1_Tick); //Link the Tick event of timer1 to timer1_Tick
    }
    
    DateTime _fromDate; //Set a new variable of name _fromDate which will be used to get the _fromDate value of ViewSchedule.cs
    DateTime _toDate; ////Set a new variable of name _toDate which will be used to get the _toDate value of ViewSchedule.cs
    
    private void timer1_Tick(object sender, EventArgs e)
    {
        if (Form1.DateChanged) //Check if a change has been done recently
        {
            Form1.DateChanged = false; //Set the change to false so that the timer won't repeat
            _fromDate = Form1._fromDate; //Set our value of _fromDate from Form1._fromDate
            _toDate = Form1._toDate;//Set our value of _toDate from Form1._toDate
        }
    }
