     protected void btnDelete_Click(object sender, EventArgs e)
    {
        {
            string strcon = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\VC_temps.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            SqlConnection con = new SqlConnection(strcon);
            SqlCommand com = new SqlCommand("CheckUser", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("StudCode", TextBox1.Text);
            SqlParameter p2 = new SqlParameter("Pword", TextBox2.Text);
            com.Parameters.Add(p1);
            com.Parameters.Add(p2);
            con.Open();
            SqlDataReader rd = com.ExecuteReader();
            if (rd.HasRows)
            {
                con.Close();
                con.Open();
                string command = @"DELETE FROM Student WHERE StudCode = @StudCode";
                SqlCommand com2 = new SqlCommand(command, con);
                SqlParameter q1 = new SqlParameter("@StudCode", Session["StudCode"]);
                com2.Parameters.Add(q1); // Also com2 now
                com2.ExecuteNonQuery(); // Added to run the query
                Response.Redirect("Default.aspx");
            }
            else
            {
                Labelinfo.Text = "Invalid username or password.";
            }
        }
    }
