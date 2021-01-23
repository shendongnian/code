    public IEnumerable<Squad> GetSquadsByIDs(IEnumerable<int> squadIDs) {
      if (squadIDs == null || !squadIDs.Any()) {
        throw new ArgumentNullException("squadIDs");
      }
      var condition = PredicateBuilder.Make<Squad>(s => false);
      foreach (var squadID in squadIDs) {
        int squadIDValue = squadID;
        condition = PredicateBuilder.Or<Squad>(condition, s => s.SquadID == squadIDValue);
      }
      var db = m_DalContextProvider.GetContext();
      return db.Squads.Where(condition);
    }
