    public void FillTable(DataTable myTable, IEnumerable<MyObject> readings)
    {
        var index=0;
        try
        {
            dt.BeginLoadData();
            foreach(var reading in readings) {
                LoadRow(myTable, reading, index++); 
            }
        }
        finally
        {
            dt.EndLoadData();
        }
    }
