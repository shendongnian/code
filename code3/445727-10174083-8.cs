    string query = @"INSERT INTO session (PK_Id, user_id, login_time, machine_ip, machine_fingerprint) 
                                 VALUES (UUID(), @UId, @LogInTime, @MIp, @MFingerPrint); 
                     SELECT PK_Id FROM session WHERE login_time=@LogInTime AND machine_fingerprint=@MFingerPrint; //or something similar which gives you the exact same id - UUID
                    ";
    try
    {
        if (_conn.State != ConnectionState.Open)
            _conn.Open();
        MySqlCommand cmd = new MySqlCommand(query, _conn);
        cmd.Parameters.AddWithValue("@UId", Utility.usr.Id);
        cmd.Parameters.AddWithValue("@LogInTime", DateTime.Now);
        cmd.Parameters.AddWithValue("@MIp", GetMachineIP());
        cmd.Parameters.AddWithValue("@MFingerPrint", GetHardwareFingerPrint());
        
        MySqlDataReader r = cmd.ExecuteReader();
        if (r.Read()) //ensure if it is read only once, else modify your `WHERE` clause accordingly
        {
            var s = (Guid)r[0];
        }
        //or even (Guid)cmd.ExecuteScalar() would work
