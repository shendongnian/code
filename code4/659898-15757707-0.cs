    public static class MyTypeHelper
    {
       public static IList<MyType> GetMockMyTypes()
       {
          var myTypes = new List<MyType>();
    
          var myMock1 = new Mock<MyType>().Object;
          Mock.Get(myMock1)
              .Setup(m => m.Equals(It.Is<MyType>(x => ReferenceEquals(x, myMock1))))
              .Returns(true);
          Mock.Get(myMock1).Setup(m => m.IsActive).Returns(false);
          myTypes.Add(myMock1);
    
          var myMock2 = new Mock<MyType>().Object;
          Mock.Get(myMock2)
              .Setup(m => m.Equals(It.Is<MyType>(x => ReferenceEquals(x, myMock2))))
              .Returns(true);
          Mock.Get(myMock2).Setup(m => m.IsActive).Returns(true);
          myTypes.Add(myMock2);
    
          return myTypes;
       }
    }
