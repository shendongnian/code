    private void login_Click(object sender, EventArgs e)
    {
        Program.Context.MainForm = new MainForm();
    
        // close login form
        this.Close();
    
        // set up context to track main form instead of login
        Program.Context.MainForm.Show(); 
    }
