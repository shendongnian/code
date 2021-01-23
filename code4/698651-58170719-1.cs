    public class AClass
    {
        public AInterface Value1 { get; private set; }
        public IEnumerable<int> Value2 { get; private set; }
        public AClass(AInterface value1, IEnumerable<int> value2)
        {
            Value1 = value1;
            Value2 = value2;
        }
    }
    public interface AInterface
    {
    }
