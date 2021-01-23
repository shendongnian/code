    public class Sequence<T> : IEnumerable<T>
    {
      public T Start { get; private set; }
      public T Interval { get; private set; }
      private Func<T, T, T> Adder { get; set; }
      public Sequence(T start, T interval, Func<T,T,T> adder)
      {
        Start = start;
        Interval = interval;
        Adder = adder;
      }
      public IEnumerator<T> GetEnumerator()
      {
        for (T n = Start; ; n = Adder.Invoke(n, Interval))
          yield return n;
      }
      IEnumerator IEnumerable.GetEnumerator()
      {
        return this.GetEnumerator();
      }
    }
