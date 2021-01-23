    protected override void OnAfterInstall(IDictionary savedState)
    {
        base.OnAfterInstall(savedState);
        // your code here
        // to simple test if it runs:
        MessageBox.Show("Everything OK!", "After Install", MessageBoxButtons.OK);
    }
    protected override void OnAfterUninstall(IDictionary savedState)
    {
        base.OnAfterUninstall(savedState);
        // your code here
        // to simple test if it runs:
        MessageBox.Show("Everything OK!", "After Uninstall", MessageBoxButtons.OK);
    }
