    DataTable dt = new DataTable();
    dt.Columns.Add("ID");
    dt.Columns.Add("Blah1");
    dt.Columns.Add("Blah2");
    for (int i = 1; i < 5; i++) {
        DataRow dr = dt.NewRow();
        dr["ID"] = i;
        dr["Blah1"] = "Blah1" + i.ToString();
        dr["Blah2"] = "Blah2" + i.ToString();
        dt.Rows.Add(dr);
    }
    var Query1 = from row in dt.AsEnumerable()
                 select new { ID = row["ID"], Blah1 = row["Blah1"] };
    DataTable newDT = new DataTable();
    newDT.Columns.Add("ID");
    newDT.Columns.Add("Blah1");
    Query1.ToList().ForEach(r => newDT.Rows.Add(r));
