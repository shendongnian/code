            var command = new SqlCommand();
            command.CommandText = createSQLQuery(command);
            command.Connection = connection;
            dataGridView1.DataSource = GetData(command);
            
            debugMySQL();
    
        }
    
        public DataTable GetData(SqlCommand cmd)
        {
            //SqlConnection con = new SqlConnection(connString);
            //SqlCommand cmd = new SqlCommand(sqlcmdString, cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            connection.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            connection.Close();
            return dt;
        }
