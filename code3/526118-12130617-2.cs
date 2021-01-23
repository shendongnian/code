    connstr = @"Data Source=.\sqlexpress;Integrated Security=SSPI;Initial Catalog=Test;";
    string sql = "select WidgetId, WidgetName, WidgetValue, CreatedDt, ModifiedDt from dbo.widgets";
    using (connection = new SqlConnection(connstr))
    {
        connection.Open();
        using (command = new SqlCommand(sql, connection))
        using (IDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                Console.Write(reader.GetValue<int>(reader.GetOrdinal("WidgetId")).ToString());
                Console.Write("\t");
                Console.Write(reader.GetValue<string>(reader.GetOrdinal("WidgetName")));
                Console.Write("\t");
                Console.Write(reader.GetValue<int>(reader.GetOrdinal("WidgetValue")));
                Console.Write("\t");
                Console.Write(reader.GetValue<DateTime>(reader.GetOrdinal("CreatedDt")));
                Console.Write("\t");
                Console.Write(reader.GetValue<DateTime>(reader.GetOrdinal("ModifiedDt")));
                Console.Write("\n");
            }
        }
    }
