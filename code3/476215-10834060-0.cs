    public interface ICommonInterface
    {
        string SomeCommonProperty { get; set; }
    }
    public class AA : ICommonInterface
    {
        public string SomeCommonProperty
        {
            get;set;
        }
    }
    public class BB : ICommonInterface
    {
        public string SomeCommonProperty
        {
            get;
            set;
        }
    }
