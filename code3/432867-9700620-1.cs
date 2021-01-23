    public class XParameter : BaseParameter
    {
        public readonly BaseParameter TypeFoo = new XParameter();
        public readonly BaseParameter TypeBar = new XParameter();
    }
    public class YParameter : BaseParameter
    {
        public readonly BaseParameter TypeFoo = new YParameter();
        public readonly BaseParameter TypeBar = new YParameter();
    }
