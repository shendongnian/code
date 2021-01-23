    private System.Threading.Timer checkNumberTimer;
    private int currentNumber;
    private void InitTimer()
    {
        //start immediately, interval is in TimeSpan
        checkNumberTimer = new System.Threading.Timer(
            timer_Elapsed,
            null,
            TimeSpan.Zero,
            Properties.Settings.Default.Interval
        );
    }
    private void timer_Elapsed(Object state)
    {
        int oldNumber = currentNumber;
        currentNumber  =  CheckNumber();
        if( oldNumber != currentNumber  )
            ShowNewNumber( currentNumber );
    }
