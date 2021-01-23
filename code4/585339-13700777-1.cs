    public IEnumerable<Offer> UnsealedOffers {
      get {
        return Offers.Where(o => !o.IsSealed);
      }
    }
