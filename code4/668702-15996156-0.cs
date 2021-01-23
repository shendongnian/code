    string category = "Category";
    string productId = "ProductId";
    List<string[]> tempList = db.Select(category, productID); //Not necessarily correct (I'm not familiar with MySQL). Do what you need to do to create the List<string[]>
    DataTable table = new DataTable();
    DataRow row;
    table.Columns.Add(category);
    table.Columns.Add(productId);
    for (int x = 0; x <= tempList.Count; x++)
    {
       row = table.NewRow();
       row[category] = tempList[x][1];
       row[productId] = tempList[x][0];
       table.Rows.Add(row);
    }
          
