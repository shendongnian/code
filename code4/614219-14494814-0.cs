    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            SqlCommand cmd;
            str = "Insert into login1 values ('" + txtbx_Uname.Text + "', '" + txtbx_Pwd.Text + "', '" + txtbx_Email.Text + "', '" + txtbx_Dob.Text + "', " + txtbx_Phone.Text + ")";
     " _    
    & "SELECT @@IDENTITY AS int32;"
            con.Open();
            cmd = new SqlCommand(str, con);    
      int n = Convert.ToInt32(cmd.ExecuteScalar());  
               
            if(n==1)
     lbl_Error.Visible = true;
            lbl_Error.Text = "Registration Success";  
                Response.Redirect("Login.aspx");
            con.Close();
        }
        catch
        {
            lbl_Error.Visible = true;
            lbl_Error.Text = "SQL Server Error. Pleaase try after sometime";
        }
    }
