    public void wait(int min)
        {
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            if (min == 0 || min < 0) return;
            //Console.WriteLine("start wait timer");
            timer1.Interval = min;
            timer1.Enabled = true;
            timer1.Start();
            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                //Console.WriteLine("stop wait timer");
            };
            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }
