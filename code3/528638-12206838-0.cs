    [TestMethod]
    public void Test_NHibernate_Query()
    {
        //Create the data in the database necessary to test my nhibernate query
        CreateDataForUnitTest();
    
    	IInventoryRepository target = new InventoryRepository(nhibernateSession);
    
    	IList<InventoryView> inventoryRecords = target.GetContainerInventory(productId);
    
    	Assert.AreEqual(1, inventoryRecords.Count);
    }
    [TestCleanup]
    public void CleanUp()
    {
    	DeleteAll<Order>();
    	DeleteAll<Company>();
    }
    public void DeleteAll<T>() where T : Entity
    {
    	NHibernate.ISession session = SessionFactory.GetCurrentSession();
    
    	using (NHibernate.ITransaction tran = session.BeginTransaction())
    	{
    		IList<T> items = session.CreateCriteria<T>()
    			.List<T>();
    
    		foreach (T p in items)
    		{
    			session.Delete(p);
    		}
    
    		tran.Commit();
    	}
    }
