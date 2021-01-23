    while (reader.Read())
    {
        int intCol = reader["MyIntColumn"] as int? ?? -1;
        string stringCol = reader["MyStringColumn"] as string ?? "NULL VALUE";
        DateTime dateCol = reader["MyDateColumn"] as DateTime? ?? new DateTime(1800, 1, 1);
    }
