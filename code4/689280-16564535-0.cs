    const string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\xp\Desktop\HydroDatabase.accdb";
    const string commandText = "INSERT Into HydroLog(WaterFlow,TurbineRPM) Values(@data1, @data2)";
    
    string[] data = _serialPort.ReadExisting().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
    using(var connect = new OleDbConnection(connectionString))
    {
        using(var command = new OleDbCommand(commandText, connect))
        {
            command.Parameters.AddWithValue("@data1", data[0]);
            command.Parameters.AddWithValue("@data2", data[1]);
            
            connect.Open();
            command.ExecuteNonQuery();
        }
    }
