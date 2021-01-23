        var query = from row in dataTable.AsEnumerable()
                    group row by row["cname"] into g
                    select new {    cname = g.Key,
                                    tname = g.First()["tname"] ,
                                    text = String.Join(", ", g.Select(r=>r["text"].ToString()).ToArray()),
                                    allowgrouping = g.First()["allowgroupping"]
                    };
        
        foreach (var row in query)
        {
            resultDataTable.Rows.Add(row.cname, row.tname, row.text, row.allowgrouping);
        }
