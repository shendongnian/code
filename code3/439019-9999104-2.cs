    [TestClass]
    public class MyClassTests
    {
       [TestMethod]
       public void ShouldCallAccountRepositoryToGetAccount()
       {
          FakeRepository fakeRepository = new FakeRepository();
    
          MyClass myClass = new MyClass(fakeRepository);
    
          long anyId = 1234;
    
          Account account = myClass.GetAccountEntityBy(anyId);
    
          Assert.IsTrue(fakeRepository.GetAccountFromDatabaseWasCalled);
          Assert.IsNotNull(account);
       }
    }
    
    public class FakeRepository : IAccountRepository
    {
       public bool GetAccountFromDatabaseWasCalled { get; private set; }
       public Account GetAccountFromDatabase(long id)
       {
          GetAccountFromDatabaseWasCalled = true;
          
          return new Account();
       }
    }
