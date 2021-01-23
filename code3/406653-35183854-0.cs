         [SetUp]
         public void LaunchTest()
         {
            NavigateTo<LogonPage>().LogonAsCustomerAdministrator();
         }
         [TearDown]
         public void StopTest()
         {
            // logoff
         }
         [Test]
         public void Test1()
         {...}
         [Test]
         public void Test2()
         {...}
