    // Keep a global variable for the previous index
    int prevIndex = 0;
    private void tabControl_Selected(object sender, TabControlEventArgs e)
    {
        TabControl tc = sender as TabControl;
        if (tc != null)
        {
            bool letSwitchHappen = validateTabControls(tc.SelectedIndex);
            if (!letSwitchHappen)
            {
                tc.SelectedIndex = prevIndex;
            }
            prevIndex = tc.SelectedIndex;
        }
    }
