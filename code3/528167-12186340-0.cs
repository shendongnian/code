    private Order LatestOrderOver(Func<Order, bool> f) {
      return
        session.QueryOver<Order>()
        .Where(f)
        .OrderBy(sr => sr.CompleteUtcTime).Desc
        .Take(1)
        .SingleOrDefault<Order>();
    }
    public Order LatestOrderOver(decimal amount) {
      return LatestOrderOver(o => o.Amount > amount);
    }
    public Order LatestAmericanOrderOver(decimal amount) {
      return LatestOrderOver(o => o.Amount > amount && o.Country == "USA");
    }
