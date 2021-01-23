    interface IUser
    {
    	int Id { get; }
    }
    class User : IUser
    {
    	public int Id { get;set; }
    }
    
    interface IUsers
    {
    	IUser GetById(int id);
    }
    class Users : IUser
    {
    	public IUser GetById(int id)
    	{
    		// TODO: make call db call
    		// TODO: parse the result
    		// TODO: and return new User instance with all the data from db
    		return new User{ Id = id };
    	}
    }
    
    [TestMethod]
    public void MyMoq()
    {	
    	// TODO: prepare/mock database. That's whole another story.
    
        var users = new Users();
    
        // act
        var user = users.GetById(10);
    
        // assert
        Assert.AreEqual(10, user.Id);
    }
