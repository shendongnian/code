    Dictionary<string, Root> hair = new Dictionary<string, Root>();
    hair.Add(
      new RootItem<int>()
          {
            Name = "None",
            Children = new List<int>() {1, 2, 3, 4}
          }
    );
    hair.Add(
      new RootItem<decimal>()
          {
            Name = "None",
            Children = new List<decimal>() {1m, 2m, 3m, 4m}
          }
    );
