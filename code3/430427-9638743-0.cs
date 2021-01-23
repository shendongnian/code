    DemoService ctx = new DemoService(new Uri("http://services.odata.org/OData/OData.svc/"));
    DataServiceQuery<Product> products = ctx.Products;
    
    DataServiceQuery<Product> q = (DataServiceQuery<Product>)products.Where(p => p.Name == "Bread").Skip(10);
    MethodCallExpression skipCall = (MethodCallExpression)q.Expression;
    q = (DataServiceQuery<Product>)q.Provider.CreateQuery<Product>(skipCall.Arguments[0]);
    Console.WriteLine(q);
