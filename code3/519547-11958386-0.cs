    class MyForm : Form
    {
        [...]
        private Object justForLocking = new Object();
        private Boolean safeToProceed = true;
        [...]
        private void timer_Tick(object sender, EventArgs e)
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
