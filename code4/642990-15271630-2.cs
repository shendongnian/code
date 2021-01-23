        // create the collection
        List<DataTable> dts = new List<DataTable>();
        // add some test datatables
        for (int i = 0; i < 10; i++)
        {
            var dt = new DataTable();
            dt.TableName = i.ToString();
            dt.Columns.Add("ID");
            dt.Columns.Add("col" + i.ToString());
            dt.Columns.Add("otherCol" + i.ToString());
            dt.Rows.Add(1, "x1" + i.ToString(), DateTime.Now);
            dt.Rows.Add(2, "x2" + i.ToString(), DateTime.Now);
            dts.Add(dt);
        }
        // get the ID column position in the first table
        var idPosition = dts[0].Columns["ID"].Ordinal;
        // used for storing the results
        var results = new List<IEnumerable<object>>();
        // add the columns from the first table
        results = dts[0].AsEnumerable()
            .Select(j => j.ItemArray.AsEnumerable()).ToList();
        // join all tables
        dts.Skip(1).ToList().ForEach((list) =>
        {
            results = results
            .AsEnumerable()
            .Join(
                list.AsEnumerable(),
                x => x.Skip(idPosition).First(),
                x => x["ID"],
                // select the second column
                (row1, row2) => row1.Concat(new[] { row2[1] }))
                // replace the preceding line with 
                // the following one to select the second and the third column
                //(row1, row2) => row1.Concat(new[] { row2[1], row2[2] }))
            .ToList();
        });
