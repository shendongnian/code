    interface ISession
    {
        // Common methods
    }
    interface IDynamicSession : ISession
    {
        // Methods unique to a dynamic session
    }
    interface IStaticSession : ISession
    {
        // Methods unique to a static session
    }
    
    public class DynamicSession : IDynamicSession
    {
    }
    
    public class StaticSession : IStaticSession
    {
    }
    
    public static class Session
    {
        public IDynamicSession CreateDynamic()
        {
            return new DynamicSession();
        }
    
        public IStaticSession CreateStatic()
        {
            return new StaticSession();
        }
    }
