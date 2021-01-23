    private IList<DataTable> GetTables()
    {
        IList<DataTable> tables = new List<DataTable>();
        using (StreamReader reader = new StreamReader(pathAndFile))
        {
            //pseudo-code below
            //Iterate through tables in the file: foreach(DiscoveredTable table in file)
            //parse from csv: table = GetTableFromCsv(table.DataFromTheFile);
            //add to tables collection: tables.Add(table);
        }
    
        return tables;
    }
