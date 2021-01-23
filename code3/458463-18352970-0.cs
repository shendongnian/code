    SqlConnection cn = new SqlConnection(your connection parameters)
    foreach (GridViewRow gvr in GridView1.Rows)
    {
            Label lblname = (Label)gvr.FindControl("lblname");
            Label lbllogin = (Label)gvr.FindControl("lbllogin");
            Label lblemail = (Label)gvr.FindControl("lblemail");
            cn.open();
                    SqlCommand command = new SqlCommand("INSERT INTO Employee(Name,Login_Id,Email_Id) VALUES(@lblname,@lbllogin,@lblemail)", cn);
                    command.Parameters.AddWithValue("@lblname", lblname.Text.ToString());
                    command.Parameters.AddWithValue("@lbllogin", lbllogin.Text.ToString());
                    command.Parameters.AddWithValue("@lblemail", lblemail.Text.ToString());
                    command.ExecuteNonQuery();
                    cn.Close()
    }
