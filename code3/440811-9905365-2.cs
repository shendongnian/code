    public IList<Bestellung> GetAll(Expression<Func<Order, bool>> restriction)
    {
        ISession session = SessionService.GetSession();
        IList<Order> bestellungen = session.Query<Order>()
                            .Where(restriction).ToList();
        return bestellungen;
    }
