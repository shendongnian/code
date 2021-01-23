    public struct Interval<T> {
       public T From { get; private set; }
       public T To { get; private set; }
       public Interval(T from, T to) {
         From = from;
         To = to;
       }
    }
