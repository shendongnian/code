    IQueryable<Product> SearchProducts (params string[] keywords)
    {
     IQueryable<Product> query = dataContext.Products;
     foreach (string keyword in keywords)
      {
       string temp = keyword;
       query = query.Where (p => p.Description.Contains (temp));
      }
      return query;
    }
