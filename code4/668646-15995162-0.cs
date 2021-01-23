    private void previousButton_Click(object sender, EventArgs e)
    {
        if (tabControl1.SelectedIndex > 0)
        {
            tabControl1.SelectedIndex--;
        }
    }
    private void nextButton_Click(object sender, EventArgs e)
    {
        if (tabControl1.SelectedIndex < tabControl1.TabCount - 1)
        {
            tabControl1.SelectedIndex++;
        }
    }
