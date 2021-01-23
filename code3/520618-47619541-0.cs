    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            if (Screen.AllScreens.Length > 1) //example
            {
    
    
            }
            base.WndProc(ref m);
        }
