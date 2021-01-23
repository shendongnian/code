    Main()
    {
       Timer tm = new Timer();
       tm.Interval = 20000;//Milliseconds
       tm.Tick += new EventHandler(tm_Tick);
       tm.Start();
    }
    void tm_Tick(object sender, EventArgs e)
    {
       Checking();       
    }
    
    public void Checking()
    {
       // Your code
    } 
