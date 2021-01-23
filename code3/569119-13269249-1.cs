    private void button1_Click(object sender, EventArgs e)
    {
        Thread myUltiThread = new Thread(GetCurrentDate);
        myUltiThread.IsBackground = true;
        myUltiThread.Start();
    }
    private void GetCurrentDate()
    {
        while(true)
        {
            int = DateTime.Today.Day;
        
            if(myDate == 7 && myDateToggle == false)
            {
                Task t = new Task(() => RunMonthBackUp());
                t.Start();
            }
        
            if (myDate == 8 && myDateToggle == true)
            {
                myDateToggle = false;
            }
            Thread.Sleep(1);
        }
    }
