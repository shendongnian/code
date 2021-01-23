    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegConnectionString"].ConnectionString))
    {
        con.Open();
        string inse = "insert into [user] (username, password, emailadd, fullname, country) values(@username, @password, @emailadd, @fullname, @country)";
        using (SqlCommand insertuser = new SqlCommand(inse, con))
        {
            insertuser.Parameters.AddWithValue("@username",TextBoxFA.Text);
            insertuser.Parameters.AddWithValue("@password", TextBoxEA.Text);
            insertuser.Parameters.AddWithValue("@emailadd", TextBoxRPW.Text);
            insertuser.Parameters.AddWithValue("@fullname", TextBoxPW.Text);
            insertuser.Parameters.AddWithValue("@country",DropDownList1.SelectedItem.ToString());
            try
            {
                insertuser.ExecuteNonQuery();
                Response.Redirect("login.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("<b>something really bad happened.....Please try again</b> ");
            }
            finally
            {
                con.Close();
            }
        }
    }
