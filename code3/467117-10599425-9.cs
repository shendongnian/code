    public Boolean CanExecute {
      get {
        var aggregate = Items
          .SelectMany(i => i.Columns)
          .Aggregate(
            new {
              IsEmpty = true,
              AllAreActive = true,
              AllAreInactive = true
            },
            (a, c) => new {
              IsEmpty = false,
              AllAreActive = a.AllAreActive && c.IsActive,
              AllAreInactive = a.AllAreInactive && !c.IsActive
            }
        );
        return !aggregate.IsEmpty && (aggregate.AllAreActive || aggregate.AllAreInactive);
      }
