    [TestFixture]
        public class BaseTextFixture
        {
          [TestFixtureSetup]
          public void SetUpStuff()
          {
             Console.Writeline("Base");
            OnAfterTextFixtureSetup();
          }
    
          public virtual OnAfterTextFixtureSetup()
          {
        
          }
    }
