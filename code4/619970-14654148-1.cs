    protected void Button2_Click(object sender, EventArgs e)
    {
        using (SqlConnection myConnection = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand("spSelectCustomer", myConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                myConnection.Open();
                SqlParameter custId = cmd.Parameters.AddWithValue("@CustomerId", 10);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        Label1.Text = dr["FirstName"].ToString();
                        Label2.Text = dr["LastName"].ToString();
                        Label3.Text = dr[3].ToString();
                        Label4.Text = dr["Email"].ToString();
                    }
                }
            }
        }
    }
