    public interface IRoot {}
    public class RootItem<T> : IRoot
    {
        public string Name { get; set; }
        public List<T> Children {get; set; }
    }
