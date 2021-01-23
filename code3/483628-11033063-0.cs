    private void checkBox1_checkedChanged(object sender, EventArgs e)
    {
        this.checkBox2.Enabled = !this.checkBox1.Checked;
        // If you want it to be unchecked as well as grayed out,
        // then have this code as well:
        if (!this.checkBox2.Enabled)
        {
            this.checkBox2.Checked = false;
        }
    }
