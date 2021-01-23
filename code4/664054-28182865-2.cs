    List<Item> BuildTreeAndReturnRootNodes(List<Item> flatItems){
      var byIdLookup = flatItems.ToLookup(i => i.Id);
      foreach (var item in flatItems){
        if (item.ParentId != null){
          var parent = byIdLookup[item.ParentId].First();
          parent.Children.Add(item);
        }
      }
      return flatItems.Where(i => i.ParentId == null);
    }
