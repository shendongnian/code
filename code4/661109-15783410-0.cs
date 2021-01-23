    public class MyMoq : IUsers
    {
      private readonly Mock<IUsers> userMock;
      public MyMoq(Mock<IUsers> userMock){
        this.userMock = userMock;
      }
    
      [TestMethod]
      public IUser GetById()
      {
          userMock.Setup(x => x.GetById(10)).Returns(new User());
    
          //After ?
          return new UsersDb().GetById(10);
      }
    }
