    XDocument doc = GetDocument();
    // assuming this is the correct namespace
    XNamespace s = "http://www.google.com/shopping/api/schemas/2010";
    var query =
        from product in doc.Root.Elements("entry").Elements(s + "product")
        // declare some variables to make the query cleaner
        let inventory = product.Element(s + "inventories").Element(s + "inventory")
        let price = (decimal)inventory.Element(s + "price")
        let shipping = (decimal)inventory.Element(s + "price").Attribute("shipping")
        select new
        {
            Name = (string)product.Element(s + "author").Element(s + "name"),
            Condition = (string)product.Element(s + "condition"),
            Price = price,
            Shipping = shipping,
            TotalPrice = price + shipping,
            Availability = (string)inventory.Attribute("availability"),
        };
    var dt = new DataTable();
    dt.Columns.Add("Name", typeof(string));
    dt.Columns.Add("Condition", typeof(string));
    dt.Columns.Add("Price", typeof(decimal));
    dt.Columns.Add("Shipping", typeof(decimal));
    dt.Columns.Add("TotalPrice", typeof(decimal));
    dt.Columns.Add("Availability", typeof(string));
    foreach (var product in query)
    {
        dt.Rows.Add(
            product.Name,
            product.Condition,
            product.Price,
            product.Shipping,
            product.TotalPrice,
            product.Availability
        );
    }
