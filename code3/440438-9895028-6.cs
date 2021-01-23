    List<sqlprop> sqlprop= read
        .readrows("SELECT * FROM test")
        .Tables[0]
        .Rows
        .Cast<DataRow>()
        .Select(r => {
            var ret = new sqlprop();
            foreach (var p in ret.GetType().GetProperties())
            {
                object val = r.Item[r.Table.Columns.IndexOf(p.Name)];
                p.SetValue(ret, val, null);
            }
            return ret;
         })
        .ToList();
