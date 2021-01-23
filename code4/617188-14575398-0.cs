    this.timerProgress.Tick += new System.EventHandler(this.timerProgress_Tick);
    
    public void AnimateProgBar(int milliSeconds)
    {
        if (!timerProgress.Enabled)
        {
            this.Invoke((MethodInvoker)delegate { pbStatus.Value = 0; });
            timerProgress.Interval = milliSeconds; //do not divide by 100
            timerProgress.Enabled = true;
        }
    }
    
    private void timerProgress_Tick(object sender, EventArgs e)
    {
        if (pbStatus.Value < 100)
        {
            pbStatus.Value += 1;
            pbStatus.Refresh();
        }
        else
        {
            timerProgress.Enabled = false;
        }
    }
