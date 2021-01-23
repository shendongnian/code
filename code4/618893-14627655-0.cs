    private static Dictionary<string, DataTable> _menuCache = null;
    public static DataRow[] GetMenuLayer(string fTableName, string fID, string fClause)
    {
        if (_menuCache == null) _menuCache = new Dictionary<string, DataTable>();
        if (!_menuCache.ContainsKey(fTableName)) { 
            // retrieve all records from the database the first time
            SQLCommand = "SELECT * FROM " + fTableName;
            ...
            _menuCache[fTableName] = result;
        }
        
        // query appropriate records from the cache
        var dt = _menuCache[fTableName];
        return dt.Select("MenuParent = " + fID + " AND Visible=1 AND " + fClause);
    }
