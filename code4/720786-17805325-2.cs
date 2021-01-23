	databaseEntites objEntites = null;
	var System.Data.Common.DbTransaction transaction = null;
	try
	{  
		objEntites = new databaseEntites();
		objEntites.Connection.Open();  
		transaction = objEntites.Connection.BeginTransaction();
		customer objcust=new customer();  
		objcust.id=id;  
		objcust.name="test1";  
		objcust.email="test@gmail.com";  
		objEntites.customer.AddObject(objcust);  
		order objorder=new order();  
		objorder.custid=objcust.id;  
		objorder.amount=500;  
		objEntites.order.AddObject(objorder);  
		objEntites.SaveChanges();  
		transaction.Commit();  
	}  
	catch()  
	{  
		if (transaction != null) transaction.Rollback();
	}  
	finally
	{
		if (objEntites != null && objEntites.Connection.State != System.Data.ConnectionState.Closed 
			&& objEntites.Connection.State != System.Data.ConnectionState.Broken) 
			objEntites.Connection.Close();
	}
