    void Time(object sender, EventArgs e)
    {
       if (time == 0)
       { time = 15; }
       if (time != 0)
       {
           time--;
           timestr = time.ToString();
           label.Text = timestr;
       }
       Application.DoEvents();
    }
