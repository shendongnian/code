    using (Entities dbe = new Entities())
	{
		dbe.myTable.RemoveRange(dbe.myTable.ToList());
		dbe.SaveChanges();
	}
    
    
             
