    private void LoginButtonClick(object sender, EventArgs e)
    {
        label1.Text = "Connecting";
        var bw = new BackgroundWorker();
        bw.DoWork += Login;
        bw.RunWorkerCompleted += LoginCompleted;
        backgroundWorker1.RunWorkerAsync();
    }
    private void Login(object sender, DoWorkEventArgs e)
    {
        Service.Service1 ws = new Service.Service1();
        bool success = = ws.login(username, password);
        e.Result = success;
    }
    private LoginCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        bool success = (bool)e.Result;
        if (success)
        {
            label1.Text = "You have successfully logged in";
        }
        else
        {
            label1.Text = "Wrong username and password";
        }
    }
