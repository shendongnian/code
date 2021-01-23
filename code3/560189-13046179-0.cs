    public static Distance FindByStartAndEnd(int start, int end, IQueryable<Distance> distanceList) {
      Distance item;
      if (!lookup.TryGetValue(Combine(start, end), out item) {
        item = null;
      }
      return item;
    }
