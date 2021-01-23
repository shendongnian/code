    var ds = new DataSet();
    
    var categories = ds.Tables.Add("Categories");
    var categoryIDColumn = categories.Columns.Add("CategoryID", typeof(int));
    categories.Rows.Add(new object[] { 1 });
    categories.Rows.Add(new object[] { 2 });
    categories.Rows.Add(new object[] { 3 });
    
    var products = ds.Tables.Add("Products");
    var productIDColumn = products.Columns.Add("ProductID", typeof(int));
    var productCategoryIDColumn = products.Columns.Add("CategoryID", typeof(int));
    products.Rows.Add(new object[] { 1, 3 });
    products.Rows.Add(new object[] { 2, 2 });
    products.Rows.Add(new object[] { 3, 1 });
    
    var items = ds.Tables.Add("Items");
    var itemIDColumn = items.Columns.Add("ItemID", typeof(int));
    var itemProductIDColumn = items.Columns.Add("ProductID", typeof(int));
    items.Rows.Add(new object[] { 1, 3 });
    items.Rows.Add(new object[] { 2, 2 });
    items.Rows.Add(new object[] { 3, 1 });
    
    var categoryProductsRelation = ds.Relations.Add("FK_CategoryProducts", categoryIDColumn, productCategoryIDColumn);
    var productItemsRelation = ds.Relations.Add("FK_ProductItems", productIDColumn, itemProductIDColumn);
    
    int selectedCategoryID = 1;
    var selectedCategory = categories.Select(String.Format("CategoryID = {0}", selectedCategoryID))[0];
    var filteredProducts = selectedCategory.GetChildRows(categoryProductsRelation);
    
    Console.WriteLine("selectedCategoryID == {0}", selectedCategoryID);
    Console.WriteLine("selectedCategory[categoryIDColumn] == {0}", selectedCategory[categoryIDColumn]);
    foreach (var childProduct in filteredProducts)
    {
        Console.WriteLine("filteredProducts includes:");
        Console.WriteLine(
                "\t{0} : {1}, {2} : {3}",
                productIDColumn.ColumnName,
                childProduct[productIDColumn],
                productCategoryIDColumn.ColumnName,
                childProduct[productCategoryIDColumn]);
    }
