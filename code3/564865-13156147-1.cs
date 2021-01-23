    private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
    {
        var result = MessageBox.Show("Do you want to close this application?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (result == DialogResult.No)
        {
            e.Cancel = true;
        }
    }
