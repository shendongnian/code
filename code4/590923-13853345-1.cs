    private void frmUserConfig_Load(object sender, EventArgs e)
    {
        foreach (string item in Properties.Settings.Default.checkedListBoxSystem)
        {
            checkedListBoxSystem.SetChecked(item);
        }
    }
