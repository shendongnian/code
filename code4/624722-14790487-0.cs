    private void radButtonStartWCFService_Click(object sender, EventArgs e)
    {
        try
        {
            Thread Trd = new Thread(() => StartWCFServer());
            Trd.IsBackground = true;
            Trd.Start();
            radButtonStartWCFService.Enabled = false;
            radButtonStartWCFService.Text = "WCF Server Started";
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message.ToString());
        }
    }
    private void StartWCFServer()
    {
        try
        {
            sHost = new ServiceHost(typeof(WCFService.WCFJobsLibrary));
            sHost.Open();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message.ToString());
        }
    }
