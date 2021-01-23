    var order = context.Orders.Include(p=>p.Products).Where(o=>o.Order_ID = == 11076);
    
    foreach(Product product in order.Products.ToList())
    {
      context.Entry(product).State = EntityState.Deleted;
    }
    context.Entry(order ).State = EntityState.Deleted;
    context.SaveChanges();
