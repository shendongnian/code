    private void timer1_Tick(object sender, EventArgs e)
    {
        #region BaseAddress
        Process[] test = Process.GetProcessesByName("process");
        if (test.Any())
        {
            // Process is running.
            int Base = test[0].MainModule.BaseAddress.ToInt32();
            // Perform any processing you require on the "Base" address here.
        }
        else
        {
             // Process is not running.
             // Display "Process is not running" in the label text.
        }
        #endregion
        //Other code
     }
