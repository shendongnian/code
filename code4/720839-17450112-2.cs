    public void inactivity_Inactive(object sender, EventArgs e)
    {
        var logdata1=Inactivity.GetIdleTime();
        System.Diagnostics.Debug.WriteLine(logdata1);
        MessageBox.Show("Inactive");
    }
    public void inactivity_Active(object sender, EventArgs e)
    {
        var logdata2 = Inactivity.GetIdleTime();
        System.Diagnostics.Debug.WriteLine(logdata2);
        MessageBox.Show("Active");
    }
