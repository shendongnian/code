        List<DataTable> dts = new List<DataTable>();
        for (int i = 0; i < 10; i++)
        {
            var dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("col" + i.ToString());
            dt.Rows.Add(1, "x1" + i.ToString());
            dt.Rows.Add(2, "x2" + i.ToString());
            dts.Add(dt);
        }
        var results = new List<IEnumerable<object>>();
        results = dts[0].AsEnumerable()
            .Select(j => j.ItemArray.AsEnumerable()).ToList();
        dts.ForEach((list) =>
        {
            results = results
            .AsEnumerable()
            .Join(
                list.AsEnumerable(),
                x => x.First(),
                x => x["ID"],
                (row1, row2) => row1.Union(new[] { row2[1] }))
            .ToList();
        });
