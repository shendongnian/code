    [TestFixture]
    public abstract class TestBase {
        protected Foo SystemUnderTest;
        [TestFixtureSetup]
        public void Setup() { 
            SystemUnterTest = new Foo("VALUE");
        }
        [TestFixtureTearDown]
        public void Teardown() { 
            SystemUnterTest.Close();
        }
    }
    public class Given_some_scenario : TestBase { 
        [Test]
        public void foo_should_do_something_interesting() { 
          SystemUnderTest.DoSomethingInteresting();
          Assert.IsTrue(SystemUnterTest.DidSomethingInteresting); 
        }
    }
