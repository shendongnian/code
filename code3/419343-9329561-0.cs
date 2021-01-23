    public interface IIdentifiable
    {
        string Id { get; set; }
    }
    public class ComplexInitInfo
    {
        public int SomeId { get; set; }
        public string SomethingElse { get; set; }
    }
    // this is just an example
    public interface ISomethingElseable : IIdentifiable
    {
        string SomethingElse { get; set; }
    }
