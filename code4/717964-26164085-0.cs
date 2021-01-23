	var data = connection.Query<Table1, Table2, Table3, Table3>(
			@"  SELECT * FROM Table1
			LEFT JOIN Table2 ON Table1.Id = Table1Id
			LEFT JOIN Table3 ON Table2.Id = Table2Id
			WHERE Table1.Id IN @Ids",
		(t1, t2, t3) => { t2.Table1 = t1; t3.Table2 = t2; return t3; },
		param: new { Ids = new int[] { 1, 2, 3 });
	var read = data.GroupBy(t => t.Table2).DoItForEachGroup(gr => gr.Key.Table3s.AddRange(gr)).Select(gr => gr.Key).
		GroupBy(t => t.Table1).DoItForEachGroup(gr => gr.Key.Table2s.AddRange(gr)).Select(gr => gr.Key);
		
