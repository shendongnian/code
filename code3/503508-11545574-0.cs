     //select query here and your connectionstring
     //then fill table as seen below
     SqlDataAdapter sDA = new SqlDataAdapter(query, connectionString);
     DataTable table = new DataTable();
     sDA.Fill(table);
     foreach (DataRow row in table.Rows)
     {
        string pc = (row["PCs"].ToString());
         //send files
     }
