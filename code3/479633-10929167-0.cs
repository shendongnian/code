    using (SqlConnection connect = new SqlConnection(connectionString))
        {
          using(SqlCommand command = new SqlCommand())
           {
            command.Connection = connect;
            command.CommandText = "insert into customer(name, address) values(@name, @address)";
    
            command.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar));
            command.Parameters.Add(new SqlParameter("@address", SqlDbType.VarChar));
            connect.Open();
            foreach (DataGridViewRow row in dataGridView1.Rows)
             {
              if(!row.IsNewRow)
               {
                 command.Parameters["@name"].Value = row.Cells[0].Value;
                 command.Parameters["@address"].Value = row.Cells[1].Value;
                 command.ExecuteNonQuery();
               }
             }
          }
        }
     
