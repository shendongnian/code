    //First create a delegate to update the label value
    public delegate void labelChanger(string s);
    
    //create timer object
    Timer t = new Timer();
    
    //create a generic List to store messages. You could also use a Queue instead.
    List<string> mod = new List<string>();
    
    //index for list
    int cIndex = 0;
    
    //add this in your Form Load event or after InitializeComponent()
    t.Tick += (timer_tick);
    t.Interval = 5000;//how long you want it to stay.
    t.Start();
    
    //the timer_tick method
    private void timer_tick(object s, EventArgs e)
    {
         labelWarningMessage.Invoke(new labelChanger(labelWork), mod[cIndex]);
         cIndex++;
    }
    //the method to do the actual message display
    private void labelWork(string s)
    {
         labelWARNING.Visible = true;
         labelWarningMessage.Text = "This module has a prerequisite module: " + s;
    }
