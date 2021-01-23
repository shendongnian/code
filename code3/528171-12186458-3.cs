    public Order LatestOrderOver(decimal amount)
    {
        return session.QueryOver<Order>()
           .LastOrder();
    }
    public Order LatestAmericanOrderOver()
    {
        return session.QueryOver<Order>()
            .Where(o => o.Country == "USA")
            .LastOrder();
    }
