    private System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        private void StartAsyncTimedWork()
        {
            myTimer.Interval = 5000;
            myTimer.Tick += new EventHandler(myTimer_Tick);
            myTimer.Start();
        }
        private void myTimer_Tick(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                /* Not on UI thread, reenter there... */
                this.BeginInvoke(new EventHandler(myTimer_Tick), sender, e);
            }
            else
            {
                lock (myTimer)
                {
                    /* only work when this is no reentry while we are already working */
                    if (this.myTimer.Enabled)
                    {
                        this.myTimer.Stop();
                        this.doMyDelayedWork();
                        this.myTimer.Start(); /* optionally restart for periodic work */
                    }
                }
            }
        }
