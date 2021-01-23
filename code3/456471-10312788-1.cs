    private void Main_User_Load(object sender, EventArgs e)
    {
        using (var loginForm = new Login())
        {
            Hide(); // hide main form
    
            if (loginForm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                Close(); // close main form and kill process
                return;
            }
                    
            Show(); // show main form if user logged in successfully 
        }
    }
