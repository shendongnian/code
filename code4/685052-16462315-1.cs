    //Example 1 :
    public interface IFoo
    {
        Task Bar();
    }
    var mock = new Mock<IFoo>();
    
    mock.Setup(m => m.Bar()).ReturnsTask(); //Bar() will return an empty awaitable task.
    //Example 2 :
    public interface IFoo
    {
        Task<int> Bar();
    }
    var mock = new Mock<IFoo>();
    
    mock.Setup(m => m.Bar()).ReturnsTask(); //await Bar() will return default(int)
    //Example 3 :
    public interface IFoo
    {
        Task<int> Bar();
    }
    var mock = new Mock<IFoo>();
    
    mock.Setup(m => m.Bar()).ReturnsTask(4); //await Bar() will return 4;
    //Example 4 :
    public interface IFoo
    {
        Task<int> Bar(int x, int y);
    }
    var mock = new Mock<IFoo>();
    
    mock.Setup(m => m.Bar(It.IsAny<int>(), It.IsAny<int>()))
                         .ReturnsTask<IFoo, int, int, int>((x,y) => x + y); //await Bar(x, y) will return x + y;
