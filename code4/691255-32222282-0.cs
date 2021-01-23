    minremain=1200000; //Should be in milisecond
    timerplurg.satrt();
    
     private void timerplurg_Tick(object sender, EventArgs e)
            {
           minremain = minremain - 1000;
            string Sec = string.Empty;
            string Min = string.Empty;
            if (minremain <= 0)
            {
                lblpurgingTimer.Text = "";
                timerplurg.Stop();
                return;
            }
            else
            {
                var timeSpan = TimeSpan.FromMilliseconds(Convert.ToDouble(minremain));
                var seconds = timeSpan.Seconds;
                var minutes = timeSpan.Minutes;
                if (seconds.ToString().Length.Equals(1))
                {
                    Sec = "0" + seconds.ToString();
                }
                else
                {
                    Sec = seconds.ToString();
                }
                if (minutes.ToString().Length.Equals(1))
                {
                    Min = "0" + minutes.ToString();
                }
                else
                {
                    Min = minutes.ToString();
                }
                string Totaltime = "Purge Remaing Time: " + Min + ":" + Sec;
                lblpurgingTimer.Text = Totaltime;
                }
             }
