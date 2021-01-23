         SqlConnection con = new SqlConnection(@"Data Source=SL-20\SQLEXPRESS;Initial   Catalog=TestDB;User ID=sa;Password=sl123;");
            string query = " insert into name(name)values('" + TextboxTest.Text + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
