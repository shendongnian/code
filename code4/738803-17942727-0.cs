    private void Main_FormClosing(object sender, FormClosingEventArgs e)
    {
        DialogResult dr = MessageBox.Show("Are you sure you want to quit?", "Leaving App",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (dr == DialogResult.No)
        {
            e.Cancel = true;
        }
    }
