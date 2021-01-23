    string category = "Category";
    string productId = "ProductId";
    List<string[]> tempList = db.Select(category, productID); //Not necessarily correct (I'm not familiar with MySQL). Do what you need to do to create the List<string[]>
    DataTable table = new DataTable();
    DataRow row;
    table.Columns.Add(category);
    table.Columns.Add(productId);
    foreach (string[] s in tempList)
    {
       row = table.NewRow();
       row[category] = s[0];
       row[productId] = s[1];
       table.Rows.Add(row);
    }
          
