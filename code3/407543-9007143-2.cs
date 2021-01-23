    private void button1_Click(object sender, EventArgs e)
    {
        List<ConfigOptions> itemsToSave = default(List<ConfigOptions>);
        if (autoCapsNames.Checked)
        {
            itemsToSave.Add(ConfigOptions.AutoCapsStr);
        }
        if (autoSort.Checked)
        {
            itemsToSave.Add(ConfigOptions.IntantOrganization);
        }
        if (showLinesNumbers.Checked)
        {
            itemsToSave.Add(ConfigOptions.ShowLinesNumber);
        }
        SaveConfigs(itemsToSave); // You're passing the list, and parsing it within the SaveConfigs method.
    }
