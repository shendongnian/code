    private Process _chromeProcess = new Process();
    
    private void bntCreate_Click(object sender, EventArgs e)
    {
        string chromePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            @"Google\Chrome\Application\chrome.exe");
    
        _chromeProcess.StartInfo = new ProcessStartInfo(chromePath, @"-app=http://localhost:(a local Web site)");
        _chromeProcess.Start();
    }
    
    private void btnKill_Click(object sender, EventArgs e)
    {
        _chromeProcess.Kill();
        _chromeProcess.WaitForExit();
        _chromeProcess.Close();
    }
    
    private void btnClose_Click(object sender, EventArgs e)
    {
        _chromeProcess.CloseMainWindow();
        _chromeProcess.WaitForExit();
        _chromeProcess.Close();
    }
