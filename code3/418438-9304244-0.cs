    if (categs.Length > 0)
    {
      List<Product> tmpProducts = new List<Product>();
      foreach (Category c in categs)
      {
        var tmp = ctx.Products.ToList().Where(x => x.IsUnderCategory(c));
        tmpProducts = tmpProducts.Union(tmp).ToList();
      }
      products = products.ToList().Intersect(tmpProducts).AsQueryable();
    }
