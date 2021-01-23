    var allProducts = context.Products.Where(.....what products you want to take from     db).ToList();
    
       Dictionary<String, Int32> dictionary = new Dictionary<String, Int32>();
       foreach(var product in allProducts)
       {
          Int32 value = 0;
          if(!dictionary.TryGetValue(product.Name, out value))
          {
             dictionary.Add(product.Name, product.Price);
             continue;
          }
          value += product.Price;
          dictionary.Add(product.Name, value);
       }
