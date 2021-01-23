    if (User.Identity.IsAuthenticated)
    {
        DataColumn dc = new DataColumn("isMarked", System.Type.GetType("System.Int32"));
        ds.Tables[0].Columns.Add(dc);
        string[] strArray = ds.Tables[0].AsEnumerable().Select(s => s.Field<string>("itemid")).ToArray<string>();
        HashSet<string> hset = new HashSet<string>(strArray);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
             if (hset.Contains(dr["itemid"].ToString().Trim()))
                 dr[3] = 1;
             else
                 dr[3] = 0;
        }
    }
