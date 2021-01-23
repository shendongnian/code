    public void spotcall()
    {
        string dial = Registry.CurrentUser.OpenSubKey("SOFTWARE").OpenSubKey("INTERCOMCS").GetValue("DIAL").ToString();
        // Now it no longer asks you for a reference, you have one!
        txtSendKeys.Text = dial;
        foreach (char c in txtSendKeys.Text)
        {
            sideapp.Keyboard.SendKey(c.ToString(), checkBoxPrivate.Checked);
        }
        txtSendKeys.Clear();
    }
