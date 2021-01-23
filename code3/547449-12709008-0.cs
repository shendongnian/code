    internal static class ListOfIntegrationTests {
        // finds all integration tests
        public static readonly IList<Type> IntegrationTestTypes = typeof(MyBaseIntegrationTest).Assembly
            .GetTypes()
            .Where(t => !t.IsAbstract && t.IsSubclassOf(typeof(MyBaseIntegrationTest)))
            .ToList()
            .AsReadOnly();
    
        // keeps all tests that haven't run yet
        public static readonly IList<Type> TestsThatHaventRunYet = IntegrationTestTypes.ToList();
    }
    
    // all relevant tests extend this class
    [TestFixture]
    public abstract class MyBaseIntegrationTest {
        [TestFixtureSetUp]
        public void TestFixtureSetUp() { }
    
        [TestFixtureTearDown]
        public void TestFixtureTearDown() {
            ListOfIntegrationTests.TestsThatHaventRunYet.Remove(this.GetType());
            if (ListOfIntegrationTests.TestsThatHaventRunYet.Count == 0) {
                // do your cleanup logic here
            }
        }
    }
