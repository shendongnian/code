    // in frmLogin.cs
    if(/* loginn is valid*/)
    {
        this.DialogResult = DialogResult.OK;
        this.Close();
    }
    else
    {
        MessageBox.Show("Wrong Username Or Password");
    }
