    string query = "INSERT INTO table (Date, SensorValue, Differences) VALUES (@Date, @SensorValue, @Differences)";            
    var command = new SqlCommand(query, con);
    command.Parameters.Add(new SqlParameter("@Date", System.Data.SqlDbType.DateTime));
    command.Parameters.Add(new SqlParameter("@SensorValue", System.Data.SqlDbType.Float));
    command.Parameters.Add(new SqlParameter("@Differences", System.Data.SqlDbType.Float));
    for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
    {
    	command.Parameters["@Date"].Value = Convert.ToDateTime(dataGridView1.Rows[i].Cells[0].Value);
    	command.Parameters["@SensorValue"].Value = Convert.ToDecimal(dataGridView1.Rows[i].Cells[1].Value);
    	command.Parameters["@Differences"].Value = Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value);
    	command.ExecuteNonQuery();
    }
