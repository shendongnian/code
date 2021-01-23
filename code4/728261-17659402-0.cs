    public class BaseClass
    {
       [SetUp]
       public virtual void SetUp()
       {
         //do something
       }
    
    }
    [TestFixture]
    public class DerivedClass : BaseClass
    {
      public override void SetUp()
      {
       base.SetUp(); //Call this when you want the parent class's SetUp to run, or omit it all together if you don't want it.
       //do something else, with no call to base.SetUp()
      }
       //tests run down here.
       //[Test]
       //[Test]
       //etc
    }
