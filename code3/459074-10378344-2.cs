    public class MyFakeProvider : IMyRepository
    {
       public void ChangeEmail(int employeeId, string newEmail)
       {
          //write some assert here indicating the method was called
       }
    }
    
    [Test]
    public void MyTest()
    {
       var myMock = new MyFakeProvider();
       var sut = new MyCommand(myMock);
    
       sut.Invoking(x => x.ChangeEmail(3, "my@email.com")).ShouldNotThrow();
    }
