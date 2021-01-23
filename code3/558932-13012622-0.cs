    public class BaseOfGeneric {
        protected static List<string> MyStaticList;
    }
    abstract class Base<TSub> : BaseOfGeneric 
    {
        ...
    }
