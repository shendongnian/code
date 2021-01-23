    for (int i = DtSet.Tables.Count - 1; i >= 0; i--)
    {
        var table = DtSet.Tables[i];
        if (table.TableName != "tblAccounts")
            DtSet.Tables.Remove(table);
    }
