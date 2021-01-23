    public class Widget<T> : IEquatable<Widget<T>>, IComparable<Widget<T>>
        where T : IEquatable<T>, IComparable<T>
    {
        public T value;
        public Widget(T input) { value=input; }
        public override bool Equals(object obj)
        {
            if(obj is Widget<T>)
            {
                return Equals(obj as Widget<T>);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
        public bool Equals(Widget<T> other)
        {
            return value.Equals(other.value);
        }
        public int CompareTo(Widget<T> other)
        {
            return value.CompareTo(other.value);
        }
        public static bool operator==(Widget<T> a, Widget<T> b)
        {
            return a.Equals(b);
        }
        public static bool operator!=(Widget<T> a, Widget<T> b)
        {
            return !a.Equals(b);
        }
        public static bool operator<(Widget<T> a, Widget<T> b)
        {
            return a.CompareTo(b)==-1;
        }
        public static bool operator>(Widget<T> a, Widget<T> b)
        {
            return a.CompareTo(b)==1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Widget<int> a=new Widget<int>(100);
            Widget<int> b=new Widget<int>(200);
            if(a==b||a>b)
            {
            }
        }
    }
