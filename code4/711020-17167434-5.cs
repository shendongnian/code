    private void btnTransfer_Click(Object sender, EventArgs e)
    {
        //This using statement will ensure that you still have an object reference when you return from form2...
        using (Form2 frmConn = new Form2())
        {
            frmConn.Show();
      
            String user = frmConn.UserName;
            String pass = frmConn.Password;
        
            if (!String.IsNullOrEmpty(user) && !String.IsNullOrEmpty(pass))
                //do something with them, they are valid!
        }
    }
