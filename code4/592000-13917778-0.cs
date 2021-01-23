    [DllImport("user32.dll")]
    public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, int vk);
    [DllImport("user32.dll")]
    public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    public enum KeyModifiers : uint { None = 0, Alt = 1, Control = 2, Shift = 4, Windows = 8, }
    Actions<int, string> Directories = new Dictionary<int, string>();
    const string MessageTitle = "Opps, Somthing Happened!";
    const MessageBoxButtons msgButtons = MessageBoxButtons.OK;
    const MessageBoxIcon msgIcon = MessageBoxIcon.Information;
    
    private void btnCreateShortcut_Click(object sender, EventArgs e)
    {
        if (cboModifier.SelectedIndex > 0)
        {
            uint key = (uint)Enum.Parse(typeof(KeyModifiers), cboModifier.SelectedItem.ToString());
            if (txtShortcutKey.Text != "")
                CreateHotKey(key, txtShortcutKey.Text.ToString());
            else
                MessageBox.Show("Please enter a Hot key to use", MessageTitle, msgButtons, msgIcon);
        }
        else
            MessageBox.Show("Please Select a Base Key", MessageTitle, msgButtons, msgIcon);
    }
    
    private void btnDestroyShortcuts_Click(object sender, EventArgs e)
    {
        destroyShortcuts();
    }
    
    private void quickActions_FormClosing(object sender, FormClosingEventArgs e)
    {
        destroyShortcuts();
    }
    
    protected override void WndProc(ref Message msg)
    {
        switch (msg.Msg)
        {
            case 0x0312:
                if (Actions.ContainsKey((int)msg.WParam))
                    // Preform Action
                break;
        }
        base.WndProc(ref msg);
    }
    
    
    public void destroyShortcuts()
    {
        foreach (KeyValuePair<int, string> pair in Actions)
            UnregisterHotKey(this.Handle, pair.Key);
    
        lstActiveKeys.Items.Clear();
        Actions.Clear();
    }
    
    public void CreateHotKey(uint modifier, string key)
    {
        int keyID = (Actions.Count + 1) * 100;
        Actions.Add(keyID, txtAction.Text.ToString());
        lstActiveKeys.Items.Add(modifier + "+" + key[0] + " - " + txtAction.Text.ToString());
        RegisterHotKey(this.Handle, keyID, modifier, (int)((char)key[0]));
    }
