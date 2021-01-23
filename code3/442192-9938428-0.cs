    void Main()
    {
        //Your list of objects
        List<MyObject> TheListOfMyObjects=new List<MyObject>();
    
        var dt=new DataTable();
        dt.Columns.Add("Prop1",typeof(int));
        dt.Columns.Add("Prop2",typeof(string));
        foreach (var TheObject in TheListOfMyObjects)
        {
            dt.Rows.Add(TheObject.Prop1,TheObject.Prop2);
        }
        InsertWithBulk(dt,"YourConnnectionString","MyObject");
    }
    private void InsertWithBulk(DataTable dt,string connectionString,string tableName)
    {
        using (SqlConnection destinationConnection =new SqlConnection(connectionString))
        {
            destinationConnection.Open();
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection))
            {
                bulkCopy.DestinationTableName =tableName;
    
                try
                {
                    bulkCopy.WriteToServer(dt);
                }
                catch (Exception ex)
                {
                    //Exception from the bulk copy
                }
            }
        }
    }
