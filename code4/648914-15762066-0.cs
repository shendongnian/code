    private void buttonMessageBox_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("Click \"OK\" if you agree with this", "MessageBoxTest", MessageBoxButtons.OKCancel)
            == DialogResult.OK)
        {
            MessageBox.Show("User clicked in \"OK\"");
        }
        else
        {
            MessageBox.Show("User clicked in \"Cancel\"");
        }
    }
