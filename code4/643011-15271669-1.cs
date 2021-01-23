    foreach (var brand in brandsInSqlDb)
    {
        var item = new ListItem();
        item.Header = brand.Name; // Set the text
        item.Value = brand.Value; // Set the value
        Brands.Controls.Add(item);
    }
