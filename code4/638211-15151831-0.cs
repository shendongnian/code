    public interface IMemberInstance
    {
        int xyz {get;}
    }
    
    public class MemberInstance : IMemberInstance
    {
     ... // the real class's implementation + code here
    }
    
    public class MockMemberInstance : IMemberInstance
    {
       // the test class can return a test value, or you can assign it
       // with a setter in the unit test
       int xyz { get { return 10; }}
    }
