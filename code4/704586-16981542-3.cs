    [TestMethod]
    public void TestInt()
    {
    	var repository = new Repository<int>( new[] {1, 2, 3} );
    	var intEntity = 3;
    	AssertReadWorks(repository, e => e == intEntity);
    }
    
    [TestMethod]
    public void TestString()
    {
    	var repository = new Repository<string>(new[] { "a", "b", "c" });
    	var stringEntity = "A";
    	AssertReadWorks(repository, e => string.Equals(e, stringEntity, StringComparison.OrdinalIgnoreCase));
    }
    
    [TestMethod]
    public void TestThread()
    {
    	var threadEntity = new Thread(() => { });
    	var repository = new Repository<Thread>(new[] { threadEntity, new Thread(() => { }), new Thread(() => { }) });
    	AssertReadWorks(repository, e => e.ManagedThreadId == threadEntity.ManagedThreadId);
    }
