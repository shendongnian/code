	DateTime dt1 = new DateTime(2013, 2, 1);
	DateTime dt2 = new DateTime(2013, 3, 1);
	DateTime dt3 = new DateTime(2013, 4, 1);
	
	var list1 = new List<AvailableSlot>
	{
		new AvailableSlot{DateTime = dt1, Name = "n1",},
		new AvailableSlot{DateTime = dt2, Name = "n2",},
		new AvailableSlot{DateTime = dt1, Name = "n3",},
	};
	
	var list2 = new List<AvailableSlot>
	{
		new AvailableSlot{DateTime = dt1, Name = "n1",},
		new AvailableSlot{DateTime = dt2, Name = "n2",},
		new AvailableSlot{DateTime = dt3, Name = "n3",},
	};
	
	var intersected = list1.Select (l => l.DateTime).
                            Intersect(list2.Select (l => l.DateTime));
	var lookup = list1.Union(list2).ToLookup (
                                    slot => slot.DateTime, slot => slot);
	
	lookup.Where (l => intersected.Contains(l.Key)).Select (
		slot => new 
		{
			DateTime=slot.Key, 
			Names=slot.Select (s => s.Name)
		});
