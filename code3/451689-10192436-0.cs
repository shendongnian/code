       void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            TimerCallback callback = MyTimerCallBack;
            timerWegingen = new System.Threading.Timer(callback);
            timerWegingen.Change(0, 3000);
            
        }
        
        private void MyTimerCallBack(object state)
        {
            DisplayWegingInfo();
            CaculateTimeBetweenWegingen();
        }
    
        private void DisplayWegingInfo()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(DisplayWegingInfo));
                return;
            }
    
            // at this point, we are on the UI thread, and can update the GUI elements
            this.label1.Text = DateTime.Now.ToString();
        }
    
        private void CaculateTimeBetweenWegingen()
        {
            Thread.Sleep(1000);
        }
