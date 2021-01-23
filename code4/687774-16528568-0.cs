    public class Sequence<T> : IEnumerable<T>
    {
      public T _start { get; private set; }
      public T _interval { get; private set; }
      private Func<T, T, T> Adder { get; set; }
      public Sequence(T start, T interval, Func<T,T,T> adder)
      {
        _start = start;
        _interval = interval;
        Adder = adder;
      }
      public IEnumerator<T> GetEnumerator()
      {
        for (T n = _start; ; n = Adder.Invoke(n, _interval))
          yield return n;
      }
      IEnumerator IEnumerable.GetEnumerator()
      {
        return this.GetEnumerator();
      }
    }
