    public string GenerateNestedMenus(string fTableName, string fID, string fClause)
    {
        ...
        // instead of querying DB, use the helper method
        var dt = GetMenuLayer(fTableName, fID, fClause);
        ...
        // now loop through dt Rows instead of DR.Read
        foreach (var dr in dt.Rows) {
            // here the logic is the same
        }
    }
