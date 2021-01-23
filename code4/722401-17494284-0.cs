        Timer timer = new Timer();
        timer.Interval = 1000; // 1 second
        timer.Tick += new EventHandler(timer_Tick);
        timer.Start();
        private void timer_Tick( object sender, EventArgs e ) {
            Timer timer = (Timer)sender;
            timer.Stop();
            new Form().ShowDialog();
        }
