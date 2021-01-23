       timer_Main.Enabled = true;
            MainTimer_last_Tick = DateTime.Now;
     private void timer_Calc_Remaining_Tick(object sender, EventArgs e)
            {
                int remaining_Milliseconds = (int)(MainTimer_last_Tick.AddMilliseconds(timer_Main.Interval).Subtract(DateTime.Now).TotalMilliseconds);
    .../*
            int newValue = (timer_Main.Interval -remaining_Milliseconds) ;
            progressBar1.Maximum = timer_Main.Interval+1;
            progressBar1.Value = newValue ;*/
        }
