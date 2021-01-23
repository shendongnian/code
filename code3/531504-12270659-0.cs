    public Order GetOrder(int id) {
        // ctx could also be instantiated via an IoC/DI framework, etc
        using(var ctx = CreateDataContext()) {
            return ctx.Orders.SingleOrDefault(x => x.Id == id);
        }
    }
    public void AddOrder(Order order) {
        if(order == null) throw new ArgumentNullException("order");
        // ctx could also be instantiated via an IoC/DI framework, etc
        using(var ctx = CreateDataContext()) {
            ctx.Orders.InsertOnSubmit(order);
            ctx.SubmitChanges();
        }
    }
