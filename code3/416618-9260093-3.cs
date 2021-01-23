    public static void GetFilesByGroups(string groupsQuery)
    {
        GetFilesByGroups(groupsQuery.Split('|').Select(x => int.Parse(x)));
    }
    public static void GetFilesByGroups(params int[] groups)
    {
        GetFilesByGroups((IEnumerable<int>)groups);
    }
    public static void GetFilesByGroups(IEnumerable<int> groups)
    {
        // Create the DataTable that will contain our groups values.
        var table = new DataTable();
        table.Columns.Add("Value", typeof(int));
        foreach (var group in groups)
            table.Rows.Add(group);
        using (var connection = CreateConnection())
        using (var command = connection.CreateCommand())
        {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "[dbo].[GetFiles]";
            // Add the table like any other parameter.
            command.Parameters.AddWithValue("@Groups", table);
            using (var reader = command.ExecuteReader())
            {
                // ...
            }
        }
    }
