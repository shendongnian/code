        protected void Submit_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConn = new SqlConnection(strCon))
            using (SqlCommand cmd = new SqlCommand("select * from Console where Text = @TextTmp", sqlConn))
            {
                cmd.Parameters.AddWithValue("@TextTmp", txtString.Text);
                try
                {
                    sqlConn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            txtString.Text = reader["Text"].ToString(); // Why?
                            lblMessage.Text = txtString.Text + "String is already exists";
                        }
                        else
                        {
                            lblMessage.Text = txtString.Text + "No data";
                            txtString.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
            }
        }
