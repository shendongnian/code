    var query  = from currRow in someTable
                where currRow.someCategory == someCategoryValue
                orderby currRow.createdDate descending
                select new { currRow.someCategory, currRow.createdDate, RowNum = -1 };
    var table = query.ToList().ToDataTable();
    //Placeholder RowNum column has to already exist in query results
    //So not adding a new column, but merely populating it
	int i = 0;
	foreach (DataRow row in table.Rows)
		row["RowNum"] = ++i;
    string json = JsonConvert.SerializeObject(table);
    var staticallyTypedList = JsonConvert.DeserializeAnonymousType(json, query.ToList());
    Console.WriteLine(staticallyTypedList.First().RowNum);
