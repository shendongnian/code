    private void button1_Click(object sender, EventArgs e)
    {
        if (autoCapsNames.Checked)
        {
            SaveConfigs(ConfigOptions.AutoCapsStr);
        }
        if (autoSort.Checked)
        {
            SaveConfigs(ConfigOptions.IntantOrganization);
        }
        if (showLinesNumbers.Checked)
        {
            SaveConfigs(ConfigOptions.ShowLinesNumber);
        }
    }
