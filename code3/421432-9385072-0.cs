    public List<IncomingOrderBase> GetAllOrders()
    {
        return ProductOrders.Cast<IncomingOrderBase>()
                            .Concat(ServicesOrders.Cast<IncomingOrderBase>())
                            .ToList();
    }
