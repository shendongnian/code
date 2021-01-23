    [TestMethod]
    public void RevokeSiteAdmin_SessionOver()
    {
        FakeDbContext db = new FakeDbContext();
    
        YourController controller = new YourController(db);
        var result = controller.YourAction();
        //Some Assertions
    }
