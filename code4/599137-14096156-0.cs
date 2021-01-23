    public class ClassUnderTest {
    
    public string MethodYouAreTesting(int someInput) {
    
    var networkCommunicator = GetNetworkCommunicator();
    // Do some stuff that I might want to test
    return "foo";
    
    }
    public virtual NetworkCommunicator GetNetworkCommunicator {
        return new NetworkCommunicator();
    }
    
    }
    [TestFixture]
    public class ClassUnderTestTests {
    public void GivenSomeCondition_MethodYouAreTesting_ReturnsFooString() {
    var classToTest = new TestClassUnderTest();
    var result = classToTest.MethodYouAreTesting(1);
    Assert.That(result, Is.EqualTo("foo");
    }
    }
    public class TestClassUnderTest : ClassUnderTest {
    public override GetNetworkCommunicator {
    return MockedNetworkCommunicator;
    }
    }
