    private void UpdateControls()
    {
        saveButton.Enabled = checkBox1.Checked;
        otherButton.Visible = checkBox2.Checked && textBox.Text.Length > 0;
    }
    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        UpdateControls();
    }
    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
        UpdateControls();
    }
    private void textBox_TextChanged(object sender, EventArgs e)
    {
        UpdateControls();
    }
