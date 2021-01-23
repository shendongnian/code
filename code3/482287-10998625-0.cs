     public interface IWithFOOMethod
     {
         void FooAlikeMethod(int number);
     }
     Mock<IWithFOOMethod> myMock = new Mock<IWithFOOMethod>();
     
     A a = new A(myMock.Object.FooAlikeMethod);
     myMock.Verify(call => call.Foo(It.IsAny<int>()), Times.Once())
