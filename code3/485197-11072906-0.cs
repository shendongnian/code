    private void timer1_Tick(object sender, EventArgs e)
        {
            #region BaseAddress
            Process[] test = Process.GetProcessesByName("process");
            if (test.Length > 0)
            {
                int Base = test[0].MainModule.BaseAddress.ToInt32();
            }
            else
            {
                myLabel.Text = "Process is not running";
            }
            #endregion
            //Other code
         }
