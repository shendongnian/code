        string ConnectionString = AS400ConnectionString;
        OleDbConnection _Connection = new OleDbConnection(ConnectionString);
        OleDbCommand _Command = _Connection.CreateCommand();
        
                    string strQuery = string.Empty;
                    strQuery += @"SELECT * FROM Contacts";
        
                    if (string.IsNullOrEmpty(strQuery))
                    {
                        throw (new Exception("No Library Setup"));
                    }
        
                    _Command.CommandText = strQuery;
                    if (_Connection.State != ConnectionState.Open)
                        _Connection.Open();
        
                    OleDbDataReader reader = _Command.ExecuteReader();
        
                    while (reader.Read())
                    {
        				//Your Logic
                    }
        
                    reader.Close();
                    if (_Connection.State != ConnectionState.Closed)
                        _Connection.Close();
