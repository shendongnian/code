    // When you launch the login form, I do not know what you intended to do with your
    // calls to Show() and Close() but so long as you don't instend for them to do
    // anything to the loginForm, that's fine.
    using (login loginForm = new login())
    {
        if (loginForm.ShowDialog() == DialogResult.OK)
            // Do stuff if logged in
        else
            // Do stuff if failed
    } 
    private void simpleButton1_Click(object sender, EventArgs e)
    {
        Boolean allowCnx = false;
    
        foreach (var row in myClass.ds.Tables["Users"].AsEnumerable())
            if (row[1].ToString().ToLower() == idBox.Text.ToLower() && row[2].ToString().ToLower() == mdpBox.Text.ToLower())
            {
                allowCnx = true;
            }
    
        if (allowCnx)
        {
            this.DialogResult = DialogResult.OK; // Don't set the DialogResult of a button.  Set it for the form.
        }
        else
        {
            this.DialogResult = DialogResult.Abort; // Because we didn't succeed
            XtraMessageBox.Show("Invalide Information",
                "Erreur",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }    
