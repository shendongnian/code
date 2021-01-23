    List<int> InDB = _db.Comments			
        .Where(r => model.ids.Contains(r.id))
	    .Select(r => r.id)
		.ToList();
	List<int> diff = model.ids.Except(InDB).ToList();
    //Loop through items to ADD
	foreach (int i in diff)
	{
		Comment comment = new Comment { Text = model.Text, id = i };
		_db.Comments.Add(comment);
	}
    //Loop through items to edit
	foreach (int i in InDB)
	{
		Comment comment = new Comment { Text = model.Text, id = i };
		_db.Entry(comment).State = EntityState.Modified;
	}
