    for (int i = DbTables.Rows.Count; i >=0 ; i--)
    {
        if (DbTables.Rows[i].ToString() == "SYSTEM_TABLE")
             DbTables.Rows.RemoveAt(i);
    }
