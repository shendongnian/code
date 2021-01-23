    private static DataTable BuildDataTable(Record[] records)
    {
        DataTable table = new DataTable();
        DataColumn header1 = new DataColumn("Header1", typeof(string));
        DataColumn header2 = new DataColumn("Header2", typeof(string));
        DataColumn header3 = new DataColumn("Header3", typeof(string));
        DataColumn data1 = new DataColumn("Data1", typeof(string));
        DataColumn data2 = new DataColumn("Data2", typeof(string));
        DataColumn data3 = new DataColumn("Data3", typeof(string));
        table.Columns.AddRange(
            new DataColumn[] 
            {
                header1, 
                data1,
                header2, 
                data2, 
                header3, 
                data3
            });
        foreach (Record record in records)
        {
            table.Rows.Add(
                record.Header1,
                record.Data1,
                record.Header2,
                record.Data2,
                record.Header3,
                record.Data3);
        }
        return table;
    }
