        try
        {
            string qry = "Select Userid from Faculty where Flag='A'";
            SqlCommand cmd = new SqlCommand(qry,con1);
            con1.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dc in dt.Rows)
            {
                if (TextBox1.Text == dc["Userid"].ToString())
                {
                    lblMessage.Text = string.Empty;
                    Panel1.Visible = true;
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Invalid Userid or UserId does not Exist in the Database !!!";
                }
            }
        }
        finally
        {
            con1.Close();
            con1.Dispose();
        }
