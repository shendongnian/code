    private void KillProcess(Process prc)
    {
        if (prc != null)
        {
            prc.Kill(); 
            prc.WaitForExit(); //this has an [override][2] in which you can specify time
            MessageBox.Show("debug!");
        }
    }
