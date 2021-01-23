    List<sqlprop> sqlprop= read
        .readrows("SELECT * FROM test")
        .Tables[0]
        .Cast<DataRow>()
        .Select(r => {
            var ret = new sqlprop();
            foreach (var p in ret.GetType().GetProperties())
            {
                p.SetValue(ret, rdr.GetValue(rdr.GetOrdinal(p.Name)), null);
            }
            return ret;
         })
        .ToList();
