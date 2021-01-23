    using (MySqlConnection conn = new MySqlConnection(...))
    {
        conn.Open();
        using (MySqlCommand cmd = new MySqlCommand(
           "INSERT INTO schedule_days(schedule_name,start_time,status,days,start_date,connector_id) " +
           "VALUES (:name, :time, :status, :days, :date, :connector)", conn))
        {
            cmd.Parameters.Add("name", SqlDbType.VarChar).Value = name;
            cmd.Parameters.Add("time", SqlDbType.Time).Value = dtpTime;
            cmd.Parameters.Add("status", SqlDbType.VarChar).Value = s;
            cmd.Parameters.Add("days", SqlDbType.Int).Value = day;
            cmd.Parameters.Add("date", SqlDbType.DateTime).Value = dtpDate;
            cmd.Parameters.Add("connector", SqlDbType.VarChar).Value = chkArray[i].Tag;
  
            int insertedRows = cmd.ExecuteNonQuery();
            // TODO: Validate that insertedRows is 1?
        }
    }
