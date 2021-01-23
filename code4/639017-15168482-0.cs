    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = !TryClose();
    }
    private bool TryClose()
    {
    	return DialogResult.Yes == MessageBox.Show("Are you sure?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }
