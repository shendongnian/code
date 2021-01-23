    private void timer1_Tick(object sender, EventArgs e)
    {
        #region BaseAddress
        Process[] test = Process.GetProcessesByName("process");
        if (test.Any())
        {
            int Base = test[0].MainModule.BaseAddress.ToInt32();
        }
        #endregion
        //Other code
     }
