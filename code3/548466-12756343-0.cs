    using (SqlConnection conn = new SqlConnection (ConfigurationManager.ConnectionStrings["database"].ConnectionString))
            {                
                conn.Open();
                SqlCommand cmd = new SqlCommand("InsertRecord1", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountNumber", acc.Text);
                cmd.Parameters.AddWithValue("@Amount", lblAmount.Text);
                cmd.Parameters.AddWithValue("@Provider", lblProvider.Text);
                cmd.Parameters.AddWithValue("@Mobile Number", lblNumber.Text);
                cmd.Parameters.AddWithValue("@TransNum", lblTrans.Text);
                cmd.Parameters.AddWithValue("@TransDate", lblDate.Text);
                cmd.Parameters.AddWithValue("@Status", status.Text);
                try
                {                        
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    lblMessage.Text = "Error";
                }
                finally
                {
                    conn.Close();
                }
            }
