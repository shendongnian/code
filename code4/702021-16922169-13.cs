    public void Process()
        {
            //uiScheduler - Not used
            //var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            //The Task is not necessary because the Process() called from Parallel.ForEach 
            //Task.Factory.StartNew(() =>
            //{
                //BeginInvoke or Invoke required
                lblMsg.BeginInvoke((MethodInvoker)delegate
                {
                    lblMsg.Text = "Connecting country " + Country;
                });
                pbStatus.BeginInvoke((MethodInvoker)delegate
                {
                    pbStatus.Value = 30;
                });
                System.Threading.Thread.SpinWait(50000000);
                //***********
                lblMsg.BeginInvoke((MethodInvoker)delegate
                {
                    lblMsg.Text = "executing sql for country " + Country;
                });
                pbStatus.BeginInvoke((MethodInvoker)delegate
                {
                    pbStatus.Value = 60;
                });
                System.Threading.Thread.SpinWait(50000000);
                //***********
                lblMsg.BeginInvoke((MethodInvoker)delegate
                {
                    lblMsg.Text = "sql executed successfully for country " + Country;
                });
                pbStatus.BeginInvoke((MethodInvoker)delegate
                {
                    pbStatus.Value = 100;
                });
                System.Threading.Thread.SpinWait(50000000);
            //});
            //System.Threading.Thread.SpinWait(50000000); // do work here   
        }
