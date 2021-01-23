    If(! IsPostBack)
    {
         //Create table
         
         table = new DataTable("myTable");
            DataColumn column1 = new DataColumn();
            column1.DataType = typeof(string);
            column1.ColumnName = "Part";
            DataColumn column2 = new DataColumn();
            column2.DataType = typeof(Int32);
            column2.ColumnName = "Quantity";
            DataColumn column3 = new DataColumn();
            column3.DataType = typeof(string);
            column3.ColumnName = "Ship-To";
            DataColumn column4 = new DataColumn();
            column4.DataType = typeof(string);
            column4.ColumnName = "Requested Date";
            DataColumn column5 = new DataColumn();
            column5.DataType = typeof(string);
            column5.ColumnName = "Shipping Method";
            table.Columns.Add(column1);
            table.Columns.Add(column2);
            table.Columns.Add(column3);
            table.Columns.Add(column4);
            table.Columns.Add(column5);
    
    }
