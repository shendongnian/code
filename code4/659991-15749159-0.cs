    List<Product> model = new List<Product>();
    while(reader.Read())
    {
      Product newEntry = new Product() { 
         Prod_Type = reader.GetValue(0),   // I'm ignoring the need to cast the values 
         Prod_N = reader.GetValue(1),
         Prod_d = reader.GetValue(2)
      };
      model.Add(newEntry);
    }
    // housekeeping
    return View(model);
