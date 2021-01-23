    public void PageSkipsThePagesBeforeTheRequestedPage()
    {
        var sut = new YourClass();
        var queryable = Substitute.For<IQueryable<int>>();
    
        sut.Page(queryable, 10, 50);
    
        queryable.Received().Skip(500);
    }
