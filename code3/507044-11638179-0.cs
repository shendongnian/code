    private void GridDataConnection()
    {
        using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
        {
            conn.Open();
    
            using (SqlCeCommand command = new SqlCeCommand("SELECT id,divelocation,divedate,diveduration FROM loggeddives", conn))
            {
                SqlCeDataReader readDiveResult = command.ExecuteReader();
    
                var diveList = new List<string[]>();
    
                while (readDiveResult.Read())
                {
                    string[] internalDives = new string[4];
    
                    internalDives[0] = readDiveResult.IsDBNull(0) ? "": readDiveResult.GetString(0);
                    internalDives[1] = readDiveResult.IsDBNull(1) ? "": readDiveResult.GetString(1);
                    internalDives[2] = readDiveResult.IsDBNull(2) ? "": readDiveResult.GetString(2);
                    internalDives[3] = readDiveResult.IsDBNull(3) ? "": readDiveResult.GetString(3);
    
                    diveList.Add(internalDives);
    
                    i++;
                }
            }
    
            conn.Close();
        }
    }
