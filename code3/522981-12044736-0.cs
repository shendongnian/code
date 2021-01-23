    private static bool UserConfirmedToLogout() 
    {
        return MessageBox.Show("Bla, bla?", "Logout", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK;
    }
    private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = !UserConfirmedToLogout();
    }
    private void btnLogOut_Click(object sender, EventArgs e)
    {            
        Close();
    }
