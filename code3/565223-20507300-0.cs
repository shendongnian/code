            string connectionString = ConfigurationManager.ConnectionStrings["ApplicationServices3"].ConnectionString;
            SqlConnection sqlConnection1 = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            ds.ReadXml(XDocument.Load("c:/d/SelectiveDatabaseBackup.xml").CreateReader());
            foreach (DataTable table in ds.Tables)
            {
                //Create table
                foreach (DataRow row in table.Rows)
                {
                    
                    string name = row[1].ToString();
                    string id = row[0].ToString();
                    cmd.CommandText = "INSERT  test9  VALUES ('"+ id +"','"+ name + "')";
                    cmd.Connection = sqlConnection1;
                    sqlConnection1.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection1.Close();
                }
            }
            //--------------------------
