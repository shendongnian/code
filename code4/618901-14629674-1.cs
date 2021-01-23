    private Dictionary<string, Dictionary<string, List<int>>> dDB = new Dictionary<string, Dictionary<string, List<int>>>();
    public List<int> ReadData(string fTableName, string fID, string fCluase)
    {
        string key = fTableName + "_" + fCluase;  
        if (dDB.ContainsKey(key))
        {
            Dictionary<string, List<int>> sDB = dDB[key];
            if (sDB.ContainsKey(fID)) return sDB[fID];
            return new List<int>();
        }
    
        string SQLCommand = "SELECT id, MenuParent FROM " + fTableName + " where Visible=1 AND " + fCluase + " order by MenuParent";
    
        SqlDataReader DR = new SqlDataReader();
        Dictionary<string, List<int>> nsDB = new Dictionary<string, List<int>>();
        int _id;
        string _fid;
        string _fidLast = string.Empty;
        List<int> _ids = new List<int>();
        while (DR.Read())
        {
            _id = DR.GetInt32(0);
            _fid = DR.GetString(1);
            if (_fid != _fidLast && !string.IsNullOrEmpty(_fidLast))
            {
                nsDB.Add(_fidLast, _ids);
                _ids.Clear();
            }
            _fidLast = _fid;
            _ids.Add(_id);
        }
        nsDB.Add(_fid, _ids);
        dDB.Add(key, nsDB);
        if (nsDB.ContainsKey(fID)) return nsDB[fID];
        return new List<int>();
    }
