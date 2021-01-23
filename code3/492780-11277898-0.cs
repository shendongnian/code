    public Form8(Form1 frm1): this()
    {
        // Restore the settings when loading the form
        checkBox1.Checked = Properties.Settings.Default.checkBox1;
    }
    private void form8_closing(object sender, FormClosingEventArgs e)
    {
        if (DialogResult.Yes == MessageBox.Show("Do you want to Save your Settings?",
                        "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
        {
            // Set the setting and save it
            Properties.Settings.Default.checkBox1 = checkBox1.Checked;
            Properties.Settings.Default.Save();
        }
    }
