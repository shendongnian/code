            private void button1_Click(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer1 = new DispatcherTimer();
            timer1.Interval = new TimeSpan(0, 0, 0, 1);
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }
        int tik = 60;
        void timer1_Tick(object sender, EventArgs e)
        {
            Countdown.Text = tik + " Seconds Remaining";
            if (tik > 0)
                tik--;
            else
                Countdown.Text = "Times Up";
        }
