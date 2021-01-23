    // You can just add this same event handler to every checkbox without making 4 methods for 4 checkboxes...
    private void checkBox_CheckedChanged(object sender, EventArgs e)
    {
        if (((CheckBox)sender).Checked)
            ++m_Checks;
        else
            --m_Checks;
        ModifyProgressBar();
    }
    private void ModifyProgressBar()
    {
        progressBar.Value = m_Checks * (progressBar.Maximum / 4);
    }
