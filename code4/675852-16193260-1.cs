    public class MySharedCode<TRequest, TResponse>
        where: TResponse: new()
    {
        public void MyShareMethodA()
        {
            // Shared code.
        }
    
        public void MyShareMethodB()
        {
            // Shared code.
        }
    
        public void SendRequest(TRequest request)
        {
            // Shared code with specific request.
        }
    
        public TResponse ReadRepsonse()
        {
            // Shared code with specific response.
        }
    }
