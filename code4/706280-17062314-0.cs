    public ActionResult ProductList(SomeType SomeParamIfYouNeed)
    {
      using (BluMercadosContext context = new BluMercadosContextEntities())
      {
        ObjectSet<Product> query = context.Products;
        ObjectResult<Product> queryResult = query.Execute(MergeOption.AppendOnly);
      }
    
      return PartialView("ProductList", queryResult);
    }
