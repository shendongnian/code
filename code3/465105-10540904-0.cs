    public class Widget<T> where T: IComparable
    {
        public T value;
        public Widget(T input) { value = input; }
        public bool Equals(Widget<T> other)
        {
            if(value == null)
            {
              return other == null || other.Value == null;
            }
            if(other == null) return false; //ensure next line doesn't get null pointer exception
            return value.CompareTo(other.Value) == 0;
        }
    }
