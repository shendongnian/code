    var set = new HashSet<object>();
    var indicesToRemove = new List<int>();
    for (var i = 0; i < list.Count; ++i) {
      var item = list[i];
      if (!set.Contains(item))
        set.Add(item);
      else
        indicesToRemove.Add(i);
    }
    var itemsRemovedSoFar = 0;
    foreach (var i in indicesToRemove) {
      list.RemoveAt(i - itemsRemovedSoFar);
      itemsRemovedSoFar += 1;
    }
