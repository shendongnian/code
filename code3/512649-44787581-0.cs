        Task waitForValueSettleTask;
        volatile bool valueIsChanging;
        
        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            valueIsChanging = true;
        
            if (waitForValueSettleTask == null || waitForValueSettleTask != null && (waitForValueSettleTask.IsCanceled || waitForValueSettleTask.IsCompleted || waitForValueSettleTask.IsFaulted))
            {
                waitForValueSettleTask = Task.Run(() =>
                {
                    while (valueIsChanging)
                    {
                        valueIsChanging = false;
                        Thread.Sleep(1000); // Set this to whatever settling time you'd like
                    }
        
                    // Your code goes here
                });
            }
        }
