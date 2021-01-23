    void delayTimer_Tick(object sender, EventArgs e)    
    {
        timesTicked++;
        if(timesTicked == 2)
        {
          timesTicked = 0;
          delayTimer.Stop();
          RunCPU();
        }
    }
