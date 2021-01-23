	using (var db = new MyContext())
	{
		// slow add
		db.MyObjects.Add(new MyObject { MyProperty = "My Value 1" });
		// fast add
		db.AddRangeFast(new[] {
			new MyObject { MyProperty = "My Value 2" },
			new MyObject { MyProperty = "My Value 3" },
		});
		db.SaveChanges();
	}
