    private DataSet GetData()
    {
        // create a test data set
        DataTable dt = new DataTable();
        dt.Columns.Add("stat1");
        dt.Columns.Add("lastname");
        dt.Columns.Add("firstname");
        dt.Columns.Add("lstdate");
        dt.Columns.Add("lenddate");
        dt.Columns.Add("bwrequestid");
    
        dt.Rows.Add("P", "Doe", "John", "08/16/2012", "08/16/2012", 1);
        dt.Rows.Add("P", "Doe", "Jane", "08/14/2012", "08/17/2012", 2);
        dt.Rows.Add("C", "Black", "Jack", "08/12/2012", "08/12/2012", 3);
        dt.Rows.Add("C", "Morgan", "Dexter", "08/01/2012", "08/07/2012", 4);
        dt.Rows.Add("S", "Swearengen", "Al", "08/15/2012", "08/20/2012", 5);
        dt.Rows.Add("S", "Kirk", "James T", "08/04/2012", "08/04/2012", 6);
        dt.Rows.Add("P", "Bundy", "Al", "08/07/2012", "08/07/2012", 7);
    
        DataSet ds = new DataSet();
        ds.Tables.Add(dt);
    
        return ds;
    }
