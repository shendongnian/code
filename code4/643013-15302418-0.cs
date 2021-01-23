     foreach (var brand in brandsInSqlDb)
    {
        comboBox .Header = brand.Name; // Set the text
        comboBox .Value = brand.Value; // Set the value
        Brands.Controls.Add(item);
    }
