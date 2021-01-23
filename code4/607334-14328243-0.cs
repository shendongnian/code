    var tablesToRemove = new List<DataTable>();
    foreach (DataTable table in DtSet.Tables)
    {
        if (table.TableName != "tblAccounts")
        {
            tablesToRemove.Add(table);
        }
    }
    foreach (DataTable table in tablesToRemove)
    {
        DtSet.Tables.Remove(table);
    }
