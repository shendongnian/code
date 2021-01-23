            SqlConnection sqlConn = null;
            string projId = String.Empty;
            string queryString = "SELECT * FROM project WHERE project_name='My Project'";
            
            try
            {
                sqlConn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand(queryString, sqlConn);
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        projId = reader.GetSqlValue(0).ToString();   // <-- safest way I found to get the first column's parameter -- increment the index if it is another column in your result
                    }                    
                }
                reader.Close();
                sqlConn.Close();
                return projId;                
            }
            catch (SqlException ex)
            {                
                // handle error
                return projId;
            }
            catch (Exception ex)
            {
                // handle error
                return projId;
            }
            finally
            {
                sqlConn.Close();
            }
