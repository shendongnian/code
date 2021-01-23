    DataTable workTable = new DataTable("Customers");
    
    // set constraints on the primary key
    DataColumn workCol = workTable.Columns.Add("CustID", typeof(Int32));
    workCol.AllowDBNull = false;
    workCol.Unique = true;
    
    workTable.Columns.Add("CustLName", typeof(String));
    workTable.Columns.Add("CustFName", typeof(String));
    workTable.Columns.Add("Purchases", typeof(Double));
    
    // set primary key
    workTable.PrimaryKey = new DataColumn[] { workTable.Columns["CustID"] };
