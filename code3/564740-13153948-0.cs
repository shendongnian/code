    internal class MyBusinessObject : IMyBusinessObject {
        public string Id { get; set; }
    }
    public interface IMyBusinessObject {
        public string Id { get; }
    }
