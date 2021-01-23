        private void UpdateTime()
        {
            int hours, mins, sec;
            string TimeofDate = "AM";
            currentTime = DateTime.Now;
            hours = Convert.ToInt32(currentTime.Hour.ToString());
            mins = Convert.ToInt32(currentTime.Minute.ToString());
           sec = Convert.ToInt32(currentTime.Second.ToString());
           // lbCurrentTime.Text = currentTime.ToLongTimeString();
          // label2.Text = hours.ToString() + ":" + mins.ToString() + ":" + sec.ToString();
           if (hours > 12)
           {
               hours = hours - 12;
               TimeofDate = "PM";
           }
           else TimeofDate = "AM";
           lbCurrentTime.Text = hours.ToString() + ":" + mins.ToString() + ":" + sec.ToString()+" "+TimeofDate;
            
           
        }
