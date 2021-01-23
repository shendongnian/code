    private Timer timer;
    private int i;
------------------
    string amma = myacess.Text;
    // string[] words = Regex.Split(amma,"*");
    char[] delimeter = new char[] { '*' };
    string[] words = amma.Split(delimeter, StringSplitOptions.RemoveEmptyEntries);
    //...
    timer = new Timer();
    timer.Interval = 100; //milliseconds 
    timer.Tick = += new EventHandler(timer_Tick);
    timer.Enabled = true; //start the timer
    
    i = 0;
