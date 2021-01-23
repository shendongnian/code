     public MyClass
     {
          public DataTable myTable { get; set; }
          public MyClass()
          {
               this.DataContext = this;
               DataColumn col01 = new DataColumn("col 01");
               myTable.Columns.Add(col01);
               DataColumn col02 = new DataColumn("col 02");
               myTable.Columns.Add(col02);
               DataRow row = myTable.NewRow();
               row[0] = "data01";
               row[1] = "data02";
               myTable.Rows.Add(row);
               row = myTable.NewRow();
               row[0] = "data01";
               row[1] = "data02";
               myTable.Rows.Add(row);
          }
     }
