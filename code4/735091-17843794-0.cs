    DataTable workTable = new DataTable("Customers");
    DataColumn workCol = workTable.Columns.Add("CustID", typeof(Int32));
    workCol.AllowDBNull = false;
    workCol.Unique = true;
    workTable.Columns.Add("CustLName", typeof(String));
    workTable.Columns.Add("CustFName", typeof(String));
    workTable.Columns.Add("Purchases", typeof(Double));
