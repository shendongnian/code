        DateTime startTime = DateTime.Now;
        void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan time = DateTime.Now - startTime;
            textBoxSeconds.Text = string.Format("{0:0#}", time.Seconds);
            textBoxMinutes.Text = string.Format("{0:0#}", time.Minutes);
        }
