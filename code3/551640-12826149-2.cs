	DataRowCollection rowCollection = spDataTable.Rows; 
	DataTable dt = new DataTable(); 
    foreach(DataRow dr in spDataTable.Rows)
    {
		 	object projectId = dr["ProjectID"];
		 	if (projectId == null)
		 	{
				dt.Rows.Add(dr);
		 	}
		 }
