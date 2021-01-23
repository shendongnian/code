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
       // the test class can return a test value
       int xyz(int a) { return 10; }
    }
