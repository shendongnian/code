    private static void RunConfig(string owner)
    {
        long ownerHandle;
        var settingsForm = new SettingsWindow();
        if (long.TryParse(owner, out ownerHandle))
        {
            WindowInteropHelper helper = new WindowInteropHelper(settingsForm);
            helper.Owner = new IntPtr(ownerHandle);
            NativeMethods.EnableWindow(helper.Owner, false);
            settingsForm.ShowDialog();
            NativeMethods.EnableWindow(helper.Owner, true);
        }
        else
        {
            settingsForm.ShowDialog();
        }
    }
