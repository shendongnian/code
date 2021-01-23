    private void ActivateApplication (string briefAppName) 
        {
            Process[] p=Process.GetProcessesByName (briefAppName);
            if (p.Length>0)
            {
                this.TopMost=true;
                ShowWindow (p[0].MainWindowHandle, 9);
                this.TopMost=false;
                this.Activate ();
            }
        }
