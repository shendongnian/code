    // Create a table "template"
    DataTable dt = new DataTable();
    dt.Columns.Add(new DataColumn("Name"));
    // Create a List of DataTables and add 3 identical tables
    List<DataTable> dtList = new List<DataTable>();
    dtList.AddRange(new List<DataTable>() { dt.Clone(), dt.Clone(), dt.Clone()});
    
    // Populate the 3 clones with some data
    dtList[0].Rows.Add("Imran");
    dtList[0].Rows.Add("Amir"); 
    dtList[0].Rows.Add("Asif");
    
    dtList[1].Rows.Add("Tandulkar");
    dtList[1].Rows.Add("Amir");  
    dtList[1].Rows.Add("Sheqwag");
    
    dtList[2].Rows.Add("John");
    dtList[2].Rows.Add("Sheqwag");
    dtList[2].Rows.Add("Mike");
    
    // Union the 3 clones into a single DataTable containing only distinct rows
    DataTable dtUnion = dtList
    					.Select(d => d.Select().AsEnumerable())
    					.Aggregate((current, next) => current.Union(next))
    					.Distinct(DataRowComparer.Default)
    					.CopyToDataTable<DataRow>();
