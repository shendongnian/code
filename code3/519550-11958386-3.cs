    class MyForm : Form
    {
        private System.Timers.Timer timer;
        private Object justForLocking = new Object();
        private Boolean safeToProceed = true;
        [...]
        public MyForm()
        {
            components = new Container();
            timer = new System.Timers.Timer();
            timer.Interval = 50;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Start();
            FormClosing += myForm_FormClosing;
        }
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
             // In case that this code is being executed after
             // the method myForm_FormClosing has adquired the 
             // exclusive lock over our dummy resource,
             // the timer thread will wait until the resource if released.
             // Once is released, our control flag will be set to false
             // and the timer should just return and never execute again.
             lock(justForLocking)
             {
                 if (safeToProceed)
                 {
                     // Do whatever you want to do at this point
                 }
             }
        }
        private void myForm_FormClosing(object sender, FormClosingEventArgs e)
        {
             lock(justForLocking)
             {
                 safeToProceed = false;
             }
             timer.Stop();
                 
             // Do something else
        }
        [...]
    }
