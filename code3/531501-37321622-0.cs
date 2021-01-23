    private class SchemaInfo
    {
        public bool Mandatory { get; set; }
        public int MaxLength { get; set; }
    }
    private Dictionary<string, SchemaInfo> _getSchemaInfo(OracleConnection _cn, string owner, string tableName)
    {
        DataTable _dt = _cn.GetSchema("Columns", new string[3] { owner, tableName, null });
        Dictionary<string, SchemaInfo> _dict = new Dictionary<string, SchemaInfo>();
        for (int x = 0; x < _dt.Rows.Count; x++)
        {
            DataRow _r = _dt.Rows[x];
            SchemaInfo _si = new SchemaInfo();
            object maxl = _r.ItemArray[10];
            if (maxl == DBNull.Value) maxl = -1;
            _si.Mandatory = (_r.ItemArray[8].ToString().Equals("N")) ? true : false;
            _si.MaxLength = Convert.ToInt32((maxl ?? 0));
            _dict.Add(_r.ItemArray[2].ToString(), _si);
        }
        return _dict;
    }
