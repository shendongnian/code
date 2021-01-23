     DataColumn[] primaryKeys = new DataColumn[1];
     primaryKeys[0] = shoppingCartDataTable.Columns["ProductID"];
     shoppingCartDataTable.PrimaryKey = primaryKeys;
     foreach(DataColumn dc in shoppingCartDataTable.PrimaryKey)
         Console.WriteLine(dc.ColumnName);
