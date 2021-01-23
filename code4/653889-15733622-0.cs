	var o = new SimpleObject { Stuff = "One" };
	db.SimpleObjects.Add(o);
	db.SaveChanges();
	o.Stuff = "Two"; // implicitly marks as Modified for you, since it's still Attached
	// Unnecessary
	//db.Entry(o).State = System.Data.EntityState.Modified;
	db.Entry(o).Reload(); // Works for me
