    var itemsToRemove = new List<int>();
    foreach(var item in someList)
    {
       if (someCondition)
          itemsToRemove.Add(item.Id);
    }
    foreach(var id in itemsToRemove)
    {
       var item = someList.First(l => l.Id = id)
       someList.Remove(item);
    }
