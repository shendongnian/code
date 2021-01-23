    protected void btnSubmit_Click(object sender, EventArgs e)
    {
    SqlDataReader   login = obj.Login_Validation(txtEmail.Text, txtPassword.Text);
    
    if(login.HasRows)
    {
    //Login Successfully 
    }
    else
    {
    //Login Failed
    }
    }
