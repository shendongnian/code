     string options = string.Empty; 
     using (SqlConnection sql_conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ToString()))
            {
                SqlDataAdapter sql_adapter = new SqlDataAdapter("select Value, Name from YourTable", sql_conn);
                DataSet ds = new DataSet();
                sql_adapter.Fill(ds, "TempTable");
    
                foreach (DataRow row in ds.Tables["TempTable"].Rows)
                {
                    options = "<option value='" + row["Value"] + "'>" + row["Name"] + "</option>";
                }
                sql_conn.Close();
               return options;
            }
