    private void btnLogin_Click(object sender, EventArgs e)
    {
    
        Program.isValid= true; // impliment this as method 
        if(Program.isValid)
        {
    	  this.DialogResult = DialogResult.OK;
          // or this.Close();
        }
        else
        {
          //else part code
        }
    }
