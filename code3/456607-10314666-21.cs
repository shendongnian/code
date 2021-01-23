    using (var db=new SomeDatabaseContext())
    {
    	foreach (var some in db.SomeTable.Where(x=>ls.Contains(x.friendid)).ToList())
    	{
    		some.status=true;
    		some.name=name;
    	}
    	db.SubmitChanges();
    }
