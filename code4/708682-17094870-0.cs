    private void Step4_Click(object sender, EventArgs e)
    {
        Step4.BackColor = Color.DarkRed;
        Step4.Text = "Please Wait...";
        Task.Factory.StartNew( () =>
        {
          string strMobileStation = "C:\\MWM\\MobileStation\\Station.exe";
          Process MobileStation = Process.Start(strMobileStation);
          MobileStation.WaitForInputIdle();
        })
        .ContinueWith(t =>
        {
          Step4.BackColor = Color.Lime;
          Step4.Text = "Mobile Station";
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }
