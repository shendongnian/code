    public abstract class Foo<T>
    {
        List<T> _List = new List<T>();
        public List<T> ListObject { get { return _List; } }
    }
    public class Bar : Foo<string>
    {
        public List<string> ListString
        {
            get { return ListObject; }
        }
    }
