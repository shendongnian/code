    public interface IHasMessage
    {
        string GetMessage();
    }
    
    public void test(string a, IHasMessage arg)
    {
        //Use message
    }
