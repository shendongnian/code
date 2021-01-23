    public bool IsReusable
    {
       get {
           // Handler is stateless, we can reuse the same instance
           // for multiple requests.
           return true;
       }
    }
