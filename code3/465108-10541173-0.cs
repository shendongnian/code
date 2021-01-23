    public class Widget<T> where T: IEquatable<T>
    {
        public T value;
        public Widget(T input) { value = input; }
        public bool Equals(Widget<T> w)
        {
            return (w.value.Equals(this.value));
        }
    }
