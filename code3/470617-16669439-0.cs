            DateTime MainTimer_last_Tick = DateTime.Now;
            System.Windows.Forms.Timer timer_Calc_Remaining;
            timer_Calc_Remaining.Enabled = true;
            timer_Calc_Remaining.Interval = 100;
            timer_Calc_Remaining.Tick += new System.EventHandler(this.timer_Calc_Remaining_Tick);
          
