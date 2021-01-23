    using (MySqlConnection conn = new MySqlConnection(...))
    {
        conn.Open();
        using (MySqlCommand cmd = new MySqlCommand(
           "INSERT INTO schedule_days(schedule_name,start_time,status,days,start_date,connector_id) " +
           "VALUES (:name, :time, :status, :days, :date, :connector)", conn))
        {
            cmd.Parameters.Add("name", name);
            cmd.Parameters.Add("time", dtpTime);
            cmd.Parameters.Add("status", s);
            cmd.Parameters.Add("days", day);
            cmd.Parameters.Add("date", dtpDate);
            cmd.Parameters.Add("connector", chkArray[i].Tag);
  
            int insertedRows = cmd.ExecuteNonQuery();
            // TODO: Validate that insertedRows is 1?
        }
    }
