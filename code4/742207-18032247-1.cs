	var dt = new DataTable();
	var res = new List<DataTable>();
	dt.Columns.Add("ID", typeof(int));
	dt.Columns.Add("Country", typeof(string));
	dt.Columns.Add("Supplier", typeof(string));
	dt.Rows.Add(515, "DE", "A");
	dt.Rows.Add(515, "CH", "A");  
	dt.Rows.Add(515, "FR", "A");
	dt.Rows.Add(516, "DE", "B");
	dt.Rows.Add(516, "FR", "B");
	dt.Rows.Add(517, "DE", "C");
	dt.Rows.Add(517, "IT", "C");
	var fields = new List<string>() { "Supplier", "Country"};
	var qfields = string.Join(", ", fields.Select(x => "it[\"" + x + "\"] as " + x));
	// qfields = "it[\"Supplier\"] as Supplier, it[\"Country\"] as Country"
	var q = dt
		.AsEnumerable()
		.AsQueryable()
		.GroupBy("new(" + qfields + ")", "it")
		.Select("new (it as Data)");
	foreach (dynamic d in q)
	{
		var dtemp = dt.Clone();
		foreach (var row in d.Data)
			dtemp.Rows.Add(row.ItemArray);
		res.Add(dtemp);
	}
