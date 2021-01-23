    public Order LatestOrderOver(decimal amount)
    {
        return session.QueryOver<Order>()
           .Where(o => o.Amount > amount)
           .LastOrder();
    }
    public Order LatestAmericanOrderOver()
    {
        return session.QueryOver<Order>()
            .Where(o => o.Amount > amount && o.Country == "USA")
            .LastOrder();
    }
