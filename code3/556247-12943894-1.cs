	using(var context = new XrmServiceContext(orgserv))
	{
		Contact con = context.contactSet.FirstOrDefault(c => c.Name == "Test Contact");
		if(con != null)
		{
			con.City = "NY";
			
			context.UpdateObject(con);
			context.SaveChanges();
		}
	}
