    public class ConnectionMaker
    {
    private object _lock=new object();
    
    public IConnection MakeConnection()
    {
    lock(_lock)
    {
    //
    }
    }
    }
