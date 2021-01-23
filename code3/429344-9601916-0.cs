    private Process _commandProcess = null;
    
    private void tsbStartRun_Click(object sender, EventArgs e)
    {
        _commandProcess = new Process();
        //Start process here.
    }
    
    private void tsbStopRun_Click(object sender, EventArgs e)
    {
        _commandProcess.Kill();
        MessageBox.Show("debug!");
    }
