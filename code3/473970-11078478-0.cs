    [ProtoContract]
    interface ITestBase 
    {
    }
    
    [ProtoContract]
    [ProtoInclude(1, typeof(TestTypeA))]
    [ProtoInclude(2, typeof(TestTypeB))]
    abstract class TestBase : ITestBase
    {
    }
    
    [ProtoContract]
    class TestTypeA : TestBase, ITestTypeA 
    {
    }
    
    [ProtoContract]
    interface ITestTypeA 
    {
    }
    
    [ProtoContract]
    class TestTypeB : TestBase, ITestTypeB 
    {
    }
    
    [ProtoContract]
    interface ITestTypeB 
    {
    }
