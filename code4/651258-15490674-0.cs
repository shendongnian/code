    public interface IFoo
    {
        IEnumerable<int> Integers { get; }
    }
    public class Bar
    {
        public List<int> Integers { get; private set; }
        public Bar(List<int> list)
        {
            Integers = list;
        }
    }
