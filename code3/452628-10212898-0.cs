        [TestFixture]
        public class BaseTextFixture
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
