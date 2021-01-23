            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection("Your Connection String");
            try
            {
                connection.Open();
                string spName = "YOURStoredProcudureName";
                SqlCommand sqlCmd = new SqlCommand(spName, connection);
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlDa.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //display the DataTable to a Data control like GridView for example
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Fetch Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                connection.Close();
            }
