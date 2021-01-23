    var Contents = ObjectHandler.player.Contents.ToList<Item>();
    var IDs = new HashSet<int>();
    var filtered = Contents.Where( i =>
      {
          bool result = !IDs.Contains(i.ID);
          IDs.Add(i.ID);
          return result;
      }).ToList();
     
