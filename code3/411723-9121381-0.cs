    void int GetNumberOfItemsAfterDate(DateTime dateInput) {
        // Create a sql statement with a parameter (@FirstDate)
        string sql = @"SELECT rank = Count(*)
                       FROM   table
                       WHERE  table.date >= @FirstDate";
        
        // Create a sql connection
        // Always use the using statement for this
        using (var connection = new SqlConnection(connectionString)) {
            
            // Create a sql command
            // Always use the using statement for this
            using (var command = new SqlCommand(sql, connection)) {
                
                // Pass the dateinput argument to the command, and let
                // the .NET Framework handle the conversion properly!
                command.Parameters.Add(new SqlCommand("FirstDate", dateInput));
                
                // No need for calling .Close() or .Dispose() - the using
                // statements handle that for us
                return (int)command.ExecuteScalar();
            }
        }
    }
