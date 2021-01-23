    public async void Loginbtn_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        actionReport.Text = "Trying to Connecting to the database";
        await Task.Delay(2);
        actionReport.Text = "Connected";
    }
