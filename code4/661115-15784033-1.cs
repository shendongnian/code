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
    	private readonly IUser _users;
    	public Users(IUser users)
    	{
    		_users = users;
    	}
    
    	public IUser GetById(int id)
    	{
    		// next line of code is to be tested in unit test
    		return _users.GetById(id);
    	}
    }
    
    [TestMethod]
    public void MyMoq()
    {	
    	var usersMock = new Mock<IUsers>();
        usersMock.Setup(x => x.GetById(10)).Returns(new User());
    
        var users = new Users(usersMock.Object);
    
        // act
        var user = users.GetById(10);
    
        // assert
        Assert.AreEqual(10, user.Id);
    }
