    Timer timer = new Timer();
    protected override void OnStart(string[] args)
        {
            //handle Elapsed event
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            //This statement is used to set interval to 2minute (= 60,000 milliseconds)
            timer.Interval = 120000;
            //enabling the timer
            timer.Enabled = true;
        }
     private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
           // writr code here for 
          //run your Note pad file using process.start or using batch file
        }
