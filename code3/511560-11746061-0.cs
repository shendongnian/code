       con.Open();
        int result = cmd.ExecuteNonQuery();
        con.Close();
    
        if (result != -1)
        {
            Response.Redirect("Registration2.aspx");
        }
        else {
            lblinfo.Text = "Some error has happend";
        }
