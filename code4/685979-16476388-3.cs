    var ds = new DataSet();
    
    // Add the Categories table with a CategoryID column, and add a few rows to it.
    var categories = ds.Tables.Add("Categories");
    var categoryIDColumn = categories.Columns.Add("CategoryID", typeof(int));
    categories.Rows.Add(new object[] { 1 });
    categories.Rows.Add(new object[] { 2 });
    categories.Rows.Add(new object[] { 3 });
    
    // Add the Items table with ItemID & CategoryID (FK) columns, and add a few Categories-relatable rows to it.
    var items = ds.Tables.Add("Items");
    var itemIDColumn = items.Columns.Add("ItemID", typeof(int));
    var itemCategoryIDColumn = items.Columns.Add("CategoryID", typeof(int));
    items.Rows.Add(new object[] { 11, 1 });
    items.Rows.Add(new object[] { 12, 2 });
    items.Rows.Add(new object[] { 13, 3 });
    
    // Add the Products table with ProductID & ItemID (FK) columns, and add a few Items-relatable rows to it.
    var products = ds.Tables.Add("Products");
    var productIDColumn = products.Columns.Add("ProductID", typeof(int));
    var productItemIDColumn = products.Columns.Add("ItemID", typeof(int));
    products.Rows.Add(new object[] { 21, 11 });
    products.Rows.Add(new object[] { 22, 12 });
    products.Rows.Add(new object[] { 23, 13 });
    
    // Add the FK relationships (or data relations as it were).
    var categoryItemsRelation = ds.Relations.Add("FK_CategoryItems", categoryIDColumn, itemCategoryIDColumn);
    var itemProductsRelation = ds.Relations.Add("FK_ItemProducts", itemIDColumn, productItemIDColumn);
    
    // Run through an example of a selected ID in the categories dropdown.
    int selectedCategoryID = 1;
    var selectedCategory = categories.Select(String.Format("CategoryID = {0}", selectedCategoryID))[0];
    var filteredItems = selectedCategory.GetChildRows(categoryItemsRelation);
    
    Console.WriteLine("selectedCategoryID == {0}", selectedCategoryID);
    Console.WriteLine("selectedCategory[categoryIDColumn] == {0}", selectedCategory[categoryIDColumn]);
    foreach (var childItem in filteredItems)
    {
        Console.WriteLine("filteredItems includes:");
        Console.WriteLine(
                "\t{0} : {1}, {2} : {3}",
                itemIDColumn.ColumnName,
                childItem[itemIDColumn],
                itemCategoryIDColumn.ColumnName,
                childItem[itemCategoryIDColumn]);
    }
    
    // ...and so forth.
