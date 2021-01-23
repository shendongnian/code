    void Init(){
        DateTime newDate = new DateTime(2013, 1, 1);
        timer1.Interval = 60000;  
        timer1.Enabled = true;
        timer1.Tick += new EventHandler(timer1_Tick)
        timer1.Start();
    }
    
    void timer1_Tick(object sender, EventArgs e)  
    {
         newDate = newDate.AddMonths(+3);
         lblDate.Text = newDate.ToString();
    }
