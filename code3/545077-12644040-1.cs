    List<CustomData> data = new List<CustomData>()
    				                        {
    					                        new CustomData { Id = 1, Name = "Test", Type = "Group1"},
    											new CustomData { Id = 2, Name = "Test", Type = "Group1"},
    											new CustomData { Id = 3, Name = "Test", Type = "Group1"},
    											new CustomData { Id = 4, Name = "Test", Type = "Group2"},
    											new CustomData { Id = 5, Name = "Test", Type = "Group2"},
    											new CustomData { Id = 6, Name = "Test", Type = "Group2"},
    											new CustomData { Id = 7, Name = "Test", Type = "Group3"},
    											new CustomData { Id = 8, Name = "Test", Type = "Group3"},
    											new CustomData { Id = 9, Name = "Test", Type = "Group3"},
    				                        };
	var dataDisplayedToUser = data.GroupBy(g => g.Type).Select(p => p.Key);
