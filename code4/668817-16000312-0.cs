     CsvFileDescription inputFileDescription = new CsvFileDescription
     {
         SeparatorChar = ',', 
         FirstLineHasColumnNames = true
     };
     CsvContext cc = new CsvContext();
     IEnumerable<Product> products =
         cc.Read<Product>("products.csv", inputFileDescription);
     // Data is now available via variable products.
     var productsByName =
         from p in products
         orderby p.Name
         select new { p.Name, p.LaunchDate, p.Price, p.Description };
     grid.DataSource = productsByName.ToList();
