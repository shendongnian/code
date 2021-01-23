    public List<Product> GetProducts()
    {
      using (BluMercadosContext context = new BluMercadosContextEntities())
      {
        ObjectSet<Product> query = context.Products;
        ObjectResult<Product> queryResult = query.Execute(MergeOption.AppendOnly);
      }
    
      return queryResult;
    }
