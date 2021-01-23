    public void InitTimer()
    {
        timer.Elapsed += new EventHandler(GetJSON);
        timer.Interval = 30000; //30sec*1000microsec             
        timer.Enabled = true;                       
        timer.Start();
    }
    
    void GetJSON(object sender, EventArgs e)
    {
    	//Steps to retrieve JSON
    }
