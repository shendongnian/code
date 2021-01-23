    private void btnOk_Click(Object sender, EventArgs e)
    {
        //verify if txtUser and txtPassword are correct
        if (correct)
        {
            _username = txtUser.Text;
            _password = txtPassword.Text;
        }
        this.Close();
    }
