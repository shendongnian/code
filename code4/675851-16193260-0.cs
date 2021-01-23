    public class MySharedCode
    {
        public void MyShareMethodA()
        {
            // Shared code.
        }
    
        public void MyShareMethodB()
        {
            // Shared code.
        }
    }
    
    public class SpecificCodeForASpecificClient:MySharedCode
    {
        public void SendRequest(MySpecificRequestA request)
        {
            // Specific code.
        }
    
        public MySpecificResponse ReadRepsonse()
        {
            // Specific code.
        }
    }
