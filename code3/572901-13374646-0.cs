	DataTable table = new DataTable();
	table.Columns.Add("pdtId", typeof(int));
	table.Columns.Add("price", typeof(double));
	table.Columns.Add("quantity", typeof(double));
	table.Rows.Add(1, 2, 3);	
    Session["bag101"] = table; // Putting DataTable in Session
    DataTable DtbBag101= (DataTable)Session["bag101"]; //Retrieving DataTable from Session
