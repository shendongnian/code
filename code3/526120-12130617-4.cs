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
                Console.Write(reader.GetValue<int>("WidgetId").ToString());
                Console.Write("\t");
                Console.Write(reader.GetValue<string>("WidgetName"));
                Console.Write("\t");
                Console.Write(reader.GetValue<int>("WidgetValue"));
                Console.Write("\t");
                Console.Write(reader.GetValue<DateTime>("CreatedDt"));
                Console.Write("\t");
                Console.Write(reader.GetValue<DateTime>("ModifiedDt"));
                Console.Write("\n");
            }
        }
    }
