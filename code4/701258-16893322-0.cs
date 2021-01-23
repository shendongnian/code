    public class Base<T>
    {
        public T[] Values { get; set; }
    }
    public TestCollection : Base<TestCollection>
    {
        // here, Values inherited from Base will be:
        // public TestCollection[] Values { get; set; }
    }
    public OtherCollection : Base<OtherCollection>
    {
        // here, Values inherited from Base will be:
        // public OtherCollection[] Values { get; set; }
    }
