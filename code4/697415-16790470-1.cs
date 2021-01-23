        protected void timer_Tick(object sender, EventArgs e)
        {
            lblNum.Text = string.Format("{0:dd:MM:yyyy hh:mm:ss}", DateTime.Now);
            if (DateTime.Now.Second == 30)
            {
                Thread t = new Thread(DisplayImages);
                t.Start();
                //t.Suspend();
                t.Join();
            }
        }
