    if (Cache["TreeView"] != null)
    {
        var table = Cache["TreeView"] as DataTable;
        //Do something with the DataTable
    }
    else
    {
        DataTable table = LoadData();
        Cache.Insert("TreeView", table, null, DateTime.Now.AddMinutes(1), TimeSpan.Zero);
    } 
