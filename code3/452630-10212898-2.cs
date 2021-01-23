        [TestFixture]
        public class BaseTestFixture
        {
          [TestFixtureSetup]
          public void SetUpStuff()
          {
             Console.Writeline("Base");
          }
        }
        
        [TestFixture]
        public class DeriveTestFixture : BaseTextFixture
        {
           [TestFixtureSetup]
           public void SetupOtherStuff()
           {
             Console.Writeline("Derived");
           } 
        }
