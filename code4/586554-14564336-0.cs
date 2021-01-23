    private void btn_syncContacts_Click(object sender, RibbonControlEventArgs e)
    {
         Thread t = new Thread(SplashScreenProc);
         t.Start();
         //long running code
         this.SyncContacts();
         syncingSplash.Invoke(new Action(this.syncingSplash.Close), null);
    }
    private SyncingContactsForm syncingSplash = new SyncingContactsForm();
    internal void SplashScreenProc(object param)
    {
        this.syncingSplash.ShowDialog();
    }
