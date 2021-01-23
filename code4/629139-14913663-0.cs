    var joinedItems = from slot1 in list1
                      join slot2 in list2
                      on slot1.DateTime equals slot2.DateTime into g
                      where g.Any()
                      select new AvailableSlot2
                      {
                          DateTime = slot1.DateTime,
                          Names = Enumerable.Range(slot1.Name,1).Union(g.Select(s => s.Name)).ToArray()
                      }
